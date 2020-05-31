import Cryptodome
import cfgloader
from Cryptodome.PublicKey import RSA
from RSAcipher import RSAcipher
import socket
from threading import Thread
import time

global ServerCipher
global ClientCipher
global OnlineClients
global username
global CipherCollection  # name:cipher

CipherCollection={}
OnlineClients = []

def client_pulse(conn):
    while True:
        #refresh every 5s
        time.sleep(5)
        text = "CP://" + username
        send_encypted(conn, text)
        print(CipherCollection.keys())


def decode_PM(pmsg):
    # SrcName/Hexstring
    source_username = pmsg.split("/", 1)[0]
    pmsg = pmsg.split("/", 1)[1]
    # Hex to Bytes
    pmsg = bytes.fromhex(pmsg)
    # Bytes decoee
    pmsg = ClientCipher.DcptString(pmsg)
    print("PM://" + source_username + "/" + pmsg)


def Rx(conn):
    global OnlineClients
    global CipherCollection
    while True:
        try:
            dataheader = conn.recv(4)
            dataheader = int.from_bytes(dataheader, byteorder='little')
            text = ClientCipher.DcptString(conn.recv(dataheader))
            #print (text)
            if text.split("://", 1)[0] == "SP":
                OnlineClients = text.split("://", 1)[1].split("|")
                for name in OnlineClients:
                    if name not in CipherCollection.keys():
                        modulus_request(conn, name)

                
                for name in CipherCollection.keys():
                    if name not in OnlineClients:
                        del CipherCollection[name]
                
                

            if text.split("://", 1)[0] == "BC":
                print(text.split("://", 1)[1])
            # Modulus Accept
            if text.split("://", 1)[0] == "MA":
                modulus_recv(text.split("://", 1)[1])

            if text.split("://", 1)[0] == "PM":
                decode_PM(text.split("://", 1)[1])
        except:
            time.sleep(1)


def Tx(conn):
    tp = Thread(target=client_pulse, args=(s,))
    tp.start()
    while True:
        n = input()
        text = input()
        time.sleep(1)
        send_private_message(conn, "猛男" + n, text)
        # text = "BC://"+text
        # EncyryptSend(socket,text)


def modulus_request(conn, TargetName):
    global CipherCollection
    msg = "MR://" + TargetName
    send_encypted(conn, msg)


def modulus_recv(msg):
    # Targetname/hexmodulus
    global CipherCollection

    target_username = msg.split("/", 1)[0]
    # hex to bytes
    _modulus = bytes.fromhex(msg.split("/", 1)[1])
    _components = (int.from_bytes(_modulus, byteorder='big'), 65537)
    target_cipher = RSAcipher(RSA.construct(_components))
    CipherCollection[target_username] = target_cipher


def send_private_message(conn, target_username, pmsg):
    global CipherCollection
    # string to cipherbyte
    pmsg = CipherCollection[target_username].EncptString(pmsg)
    # cipherbyte to hexstring
    pmsg = pmsg.hex()
    # Join PM://TargetName/Hexstring
    pmsg = "PM://" + target_username + "/" + pmsg
    send_encypted(conn, pmsg)


def send_encypted(conn, text):
    cipherbytes = ServerCipher.EncptString(text)
    dataheader = len(cipherbytes)
    conn.send(dataheader.to_bytes(length=4, byteorder='little'))
    conn.send(cipherbytes)


if __name__ == "__main__":
    global username
    for i in range(10):
        try:
            username = "猛男" + str(i)
            print(username)
            hostname = socket.gethostname()
            ip_address = socket.gethostbyname(hostname)
            s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
            
            server_addr =  ("173.230.151.159",12345)
            #server_addr = ("127.0.0.1", 12345)
            
            # s.bind(local_addr)
            s.connect(server_addr)
            clientkey = RSA.generate(2048)
            ClientCipher = RSAcipher(clientkey)

            # send client public key
            buffer = clientkey.n.to_bytes(256, byteorder='big')
            s.send(buffer)

            # recv server public key
            modulus = s.recv(256)
            components = (int.from_bytes(modulus, byteorder='big'), 65537)
            serverkey = RSA.construct(components)
            ServerCipher = RSAcipher(serverkey)

            # send pass
            # password = input("Input Password:")
            password = "963"
            if password != "":
                buffer = ServerCipher.EncptString(password)
                header = len(buffer)
                s.send(header.to_bytes(length=4, byteorder='little'))
                s.send(buffer)

            # send client name
            buffer = ServerCipher.EncptString(username)
            header = len(buffer)
            s.send(header.to_bytes(length=4, byteorder='little'))
            s.send(buffer)

            # recv server name
            buffer = s.recv(4)
            header = int.from_bytes(buffer, byteorder='little')
            if header != 256:
                continue
            buffer = s.recv(header)
            servername = ClientCipher.DcptString(buffer)
            print("已连接到 " + servername)
            tr = Thread(target=Rx, args=(s,))
            tr.start()
            tx = Thread(target=Tx, args=(s,))
            tx.start()
            break
        except:
            continue
