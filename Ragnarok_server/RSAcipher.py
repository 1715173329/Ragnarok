from Cryptodome.Cipher import PKCS1_OAEP


class RSAcipher:
    cipher = None

    def __init__(self, privatekey):
        self.cipher = PKCS1_OAEP.new(privatekey)

    def DcptBytes(self, cipherbytes):
        buffer = self.Slice(cipherbytes, 256)
        buffer = list(map(self.cipher.decrypt, buffer))
        clearbytes = b""
        for b in buffer:
            clearbytes += b
        return clearbytes

    def DcptString(self, cipherbytes):
        clearbytes = self.DcptBytes(cipherbytes)
        return clearbytes.decode(encoding='UTF-8')

    def EncptBytes(self, clearbytes):
        buffer = self.Slice(clearbytes, 200)

        # max 214 bytes
        buffer = list(map(self.cipher.encrypt, buffer))
        cipherbytes = b""
        for b in buffer:
            cipherbytes += b
        return cipherbytes

    def EncptString(self, clearstring):
        clearbytes = clearstring.encode(encoding='UTF-8')
        return self.EncptBytes(clearbytes)

    def Slice(self, bytesbuffer, blocksize):
        index = 0
        slice = []
        i = len(bytesbuffer) // blocksize
        for counter in range(i):
            slice.append(bytesbuffer[index:index + blocksize])
            index += blocksize
        if index != len(bytesbuffer):
            slice.append(bytesbuffer[index:])
        return slice
