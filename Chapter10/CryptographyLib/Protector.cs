using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace CryptographyLib  
{
    public static class Protector
    {
        //salt size must be at least 8 Bytes, we use 16
        private static readonly byte[] salt = Encoding.Unicode.GetBytes("9BANANAS");

        //iterations must be at least 1000, we use 2000
        private static readonly int iterations = 2000;

        public static string Encrypt(string plainText, string password){
            byte[] plainBytes = Encoding.Unicode.GetBytes(plainText);
            //AES Advanced Encryption Standart, algorithm for symmetric encryption
            var aes = Aes.Create();
            var rsa = RSA.Create();
            
            //Rfc2898DeriveBytes class can create Keys and IV
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            aes.Key = pbkdf2.GetBytes(32); //Create a 256-bit key
            aes.IV = pbkdf2.GetBytes(16); //Create a 128-bit IV
            var ms = new MemoryStream();
            //CryptoStream can encrypt or decrypt large amounts of bytes efficenly
            using(var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write)){
                cs.Write(plainBytes, 0, plainBytes.Length);
            }

            return Convert.ToBase64String(ms.ToArray());
        }

        public static string Decrypt(string cryptoText, string password){
            byte[] cryptoBytes = Convert.FromBase64String(cryptoText);
            var aes = Aes.Create();
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            aes.Key = pbkdf2.GetBytes(32);
            aes.IV = pbkdf2.GetBytes(16);
            var ms = new MemoryStream();
            using(var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write)){
                cs.Write(cryptoBytes, 0, cryptoBytes.Length);
            }
            return Encoding.Unicode.GetString(ms.ToArray());
        }
    }
}
