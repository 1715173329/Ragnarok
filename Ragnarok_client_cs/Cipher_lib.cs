using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace Cipher_lib
{
    class RSA_module
    {
        public static void RSA_pair(out string pubkey, out string privkey)
        {
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                privkey = RSA.ToXmlString(true);
                pubkey = RSA.ToXmlString(false);
            }
        } 

        public static byte[] RSAEncrypt(byte[] plainbytes,string pubkey)
        {
            byte[] cipherbytes;
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSA.FromXmlString(pubkey);
                cipherbytes = RSA.Encrypt(plainbytes, false);
                return cipherbytes;
            }
        }

        public static byte[] RSADecrypt(byte[] cipherbytes, string privkey)
        {
            byte[] plainbytes;
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSA.FromXmlString(privkey);
                plainbytes = RSA.Decrypt(cipherbytes, false);
                return plainbytes;
            }
        }
    }

    class AES_module
    {
        public static void AES_Initialize(out byte[] AES_Key, out byte[] AES_IV)
        {
            using (Aes myAes = Aes.Create())
            {
                AES_Key = myAes.Key;
                AES_IV = myAes.IV;
            }
        }

        public static byte[] AES_Encrypt(byte[] clearBytes, byte[] Key, byte[] IV)
        {
            byte[] encrypted;
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        csEncrypt.Write(clearBytes, 0, clearBytes.Length);
                        csEncrypt.Close();
                    }
                    encrypted = msEncrypt.ToArray();
                }
            }
            return encrypted;
        }

        public static byte[] AES_Decrypt(byte[] cipherbytes, byte[] Key, byte[] IV)
        {
            byte[] clearBytes;
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msDecrypt = new MemoryStream())
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Write))
                    {
                        csDecrypt.Write(cipherbytes, 0, cipherbytes.Length);
                        csDecrypt.Close();
                    }
                    clearBytes = msDecrypt.ToArray();
                }

            }
            return clearBytes;
        }
    }
}
