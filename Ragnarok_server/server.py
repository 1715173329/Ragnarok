import socket
import threading
import time
import cfgloader
global UserID
UserID={}

class server(threading.Thread):
    global UserID
    def __init__(self,a_UserID):
        threading.Thread.__init__(self)
        TargetID=UserID[a_UserID].recv(1024).decode()
        cache="Starting encrypted channel from "+a_UserID+" to "+TargetID
        UserID[a_UserID].send(cache.encode())
        #Rx Target ID
        self.a_UserID=a_UserID
        self.TargetID=TargetID
        
    def run(self):
        try:
            
            #Holding
            while 1:
                if self.TargetID in UserID:
                    UserID[self.a_UserID].send(b"In coming")
                    time.sleep(1)
                    break
                else:
                    UserID[self.a_UserID].send(b"Waiting connect...")
                time.sleep(0.5)
            
            UserID[self.a_UserID].send(b"Connection Establised.")
            
            #Start bridging
            while 1:
                cache=UserID[self.a_UserID].recv(1024)
                UserID[self.TargetID].send(cache)
                
        finally:
            print ("Disconnected with",self.a_UserID)
            UserID[self.a_UserID].close()
            del UserID[self.a_UserID]

#Load port
CFG=cfgloader.loadcfg()
server_port=int((CFG["server_port"]))
server_ip = CFG["server_ip"]
if input ("Auto gethost?(y/n)")=="y":
    server_ip = socket.gethostname()
if input("Test mode?(y/n)")=="y":
    server_ip = "127.0.0.1"
s=socket.socket(socket.AF_INET,socket.SOCK_STREAM)
#Start server
s.bind((server_ip,server_port))
s.listen(5)
print ("Listening on %d"%server_port)

while True:
    #ID auth
    while True:
        conn,addr=s.accept()
        try:
            a_UserID=conn.recv(1024).decode()
            send_cache=a_UserID+" Authorized."
            conn.send(send_cache.encode())
            print ("Connect with",a_UserID)
            break
        except:
            print ("Authorization Failed.")
            print ("Disconnected with",conn)
            conn.close()

    #Start ID's threading
    if  a_UserID not in UserID:
        UserID[a_UserID]=conn
        link=server(a_UserID)
        link.start()
    else:
        print ("Disconnected with",conn)
        conn.close()
        
