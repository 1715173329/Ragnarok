import cfgloader
import threading
from Cryptodome.PublicKey import RSA
from threading import Thread
from socket import *
from RSAcipher import RSAcipher

global serverkey
global ServerCipher
global Clients  # conn:name
global ClientsCiphers  # name:cipher
global ClientsModulus  # name:Modulus
global CliensLock


def server_pulse(conn):
    # ServerPulse
    # SP://username1|username2|username3
    clients_collection = Clients.values()
    clients_collection = "SP://" + "|".join(clients_collection)
    send_encypted(conn, clients_collection)


def distribution(conn):
    global ServerCipher
    global Clients

    try:
        text = "SM://"+Clients[conn]+" Join"
        broadcast(text)
        while True:
            buffer = conn.recv(4)
            header = int.from_bytes(buffer, byteorder='little')
            msg = ServerCipher.DcptString(conn.recv(header)).split("://", 1)

            if msg[0] == "BC":
                text = "BC://" + Clients[conn] + "/" + msg[1]
                broadcast(text)

            # Client Pulse
            # CP://ClientName
            if msg[0] == "CP":
                server_pulse(conn)

            # Modulus Request
            # MR://TGTname
            if msg[0] == "MR":
                modulus_request(conn, msg[1])

            # Private Message
            # PM://TGTname/pmsg
            if msg[0] == "PM":
                send_private_message(conn, msg[1])

    except:
        disconnect(conn)
        print("Distribution Except")
        print(Clients.values())


def modulus_request(source_conn, target_username):
    global Clients
    global ClientsModulus
    for name in Clients.values():
        if name == target_username:
            # send target client's publickey to source client
            msg = "MA://" + target_username + "/" + ClientsModulus[name].hex()
            send_encypted(source_conn, msg)
            return


def send_private_message(source_conn, msg):
    global Clients
    global ClientsCiphers
    global ClientsModulus

    # msg = TargetName/Pmsg
    target_name = msg.split("/", 1)[0]
    # Pmsg = msg.split("/",1)[1]

    for tgtConn, name in Clients.items():
        if name == target_name:
            # PM://SrcName/pmsg
            pmsg = "PM://" + Clients[source_conn] + "/" + msg.split("/", 1)[1]
            send_encypted(tgtConn, pmsg)
            return


def broadcast(text):
    print(text)
    for c in Clients.keys():
        try:
            send_encypted(c, text)
        except:
            disconnect(c)
            print(Clients.values())


def send_encypted(conn, text):
    global Clients
    global ClientsCiphers
    try:

        cipherbytes = ClientsCiphers[Clients[conn]].EncptString(text)
        header = len(cipherbytes)
        conn.send(header.to_bytes(length=4, byteorder='little'))
        conn.send(cipherbytes)
    except:
        print("EncyryptSend Exception")
        disconnect(conn)


def disconnect(conn):
    global CliensLock
    try:
        CliensLock.acquire()
        del ClientsCiphers[Clients[conn]]
        del Clients[conn]
        CliensLock.release()
        conn.close()
    except:
        print("Quit Exception")


def main():
    global serverkey
    global ServerCipher
    global Clients
    global ClientsCiphers
    global ClientsModulus
    global CliensLock

    Clients ={}
    ClientsCiphers={}
    ClientsModulus={}

    ActiveThread = []
    CliensLock = threading.Lock()

    serverkey = RSA.generate(2048)
    ServerCipher = RSAcipher(serverkey)

    server_config = cfgloader.loadcfg()
    host = server_config["server_ip"]
    port = int(server_config["server_port"])
    servername = server_config["server_name"]
    serverpass = server_config["server_password"]

    s = socket(AF_INET, SOCK_STREAM)
    s.bind((host, port))
    s.listen(5)
    print("Listening on %d" % port)
    # Start server

    while True:
        try:
            conn, addr = s.accept()
            print("Connect from:", addr)

            # recv client public key
            modulus = conn.recv(256)
            components = (int.from_bytes(modulus, byteorder='big'), 65537)
            clientkey = RSA.construct(components)
            ClientCipher = RSAcipher(clientkey)

            # send server public key
            buffer = serverkey.n.to_bytes(256, byteorder='big')
            conn.send(buffer)

            # password auth
            if serverpass != "":
                buffer = conn.recv(4)
                header = int.from_bytes(buffer, byteorder='little')
                buffer = conn.recv(header)
                clientpass = ServerCipher.DcptString(buffer)
                if clientpass != serverpass:
                    conn.close()
                    continue

            # recv client name
            buffer = conn.recv(4)
            header = int.from_bytes(buffer, byteorder='little')
            buffer = conn.recv(header)
            name = ServerCipher.DcptString(buffer)
            print(name + "Connected")

            # check client name available
            if name in Clients.values():
                conn.close()
            else:

                CliensLock.acquire()
                Clients[conn] = name
                CliensLock.release()

                client_collection = Clients.values()
                print("|".join(client_collection))

                # send server name
                buffer = ClientCipher.EncptString(servername)
                header = len(buffer)
                conn.send(header.to_bytes(length=4, byteorder='little'))
                conn.send(buffer)

                # start client thread
                t = Thread(target=distribution, args=(conn,))
                t.start()

                CliensLock.acquire()
                ClientsCiphers[name] = ClientCipher
                ClientsModulus[name] = modulus
                CliensLock.release()

                ActiveThread.append(t)

            # recycle thread
            for t in ActiveThread:
                if t.is_alive() is False:
                    t.join()

        except:
            print("ACCEPT EXCEPTION")
            conn.close()
            break


if __name__ == '__main__':
    main()
    #input("Enter to continue")
