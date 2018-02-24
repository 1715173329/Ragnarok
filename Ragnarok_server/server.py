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
                time.sleep(2)
            
            UserID[self.a_UserID].send(b"Connection Establised.")
            
            #Start bridging
            while 1:
                cache=UserID[self.a_UserID].recv(1024)
                UserID[self.TargetID].send(cache)
                
        finally:
            UserID[self.a_UserID].close()
            print ("Disconnected with",self.a_UserID)
            del UserID[self.a_UserID]

#Load port
CFG=cfgloader.loadcfg()
server_port=int((CFG["server_port"]))

#Load ip
server_ip = CFG["server_ip"]
if server_ip in ["","0.0.0.0"]:
    if "localnetwork" not in CFG or CFG["localnetwork"] == "false":
        server_ip = socket.gethostname()
    else:
        server_ips = socket.gethostbyname_ex(socket.gethostname())[-1]
        print (server_ips)
        for n in range(len(server_ips)-1):
            print ("#{0}: {1}".format(n+1,server_ips[n]))
        ltofip = int(input("Input the num of your ip:"))
        while ltofip > len(server_ip):
            ltofip = int(input("Please input again:"))
        server_ip = server_ips[ltofip-1]
print ('\nserver ip: '+server_ip)

s=socket.socket(socket.AF_INET,socket.SOCK_STREAM)
#Start server
<<<<<<< HEAD
s.bind((socket.gethostname(),server_port))
#s.bind(("127.0.0.1",server_port)) ##just for localtest
=======
#s.bind((socket.gethostname(),server_port))
s.bind((server_ip,server_port)) ##just for localtest
>>>>>>> dev
s.listen(5)
print ("Listening on %d"%server_port)

while True:
    #ID auth
    while True:
        conn,addr=s.accept()
        try:
            a_UserID=conn.recv(1024)#.decode()
            send_cache=a_UserID+" Authorized."
            conn.send(send_cache.encode())
            print ("Connect with",a_UserID)
            break
        except:
            print ("Error encoding")
            print ("=================")
            print (conn,addr)
            print (a_UserID)
            print ("=================\n")
        finally:
            pass
    
    #Start ID's threading
    if  a_UserID not in UserID:
        UserID[a_UserID]=conn
        link=server(a_UserID)
        link.start()
    else:
        conn.close()
