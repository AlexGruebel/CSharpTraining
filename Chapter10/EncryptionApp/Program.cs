using System;
using CryptographyLib;

namespace EncryptionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string plainText = "Hallo Baum";
            string password = "password";
            string cryptoText = Protector.Encrypt(plainText, password);
            Console.WriteLine($"cryptoText...: {cryptoText}");
            string encryptedText = Protector.Decrypt(cryptoText, password);
            Console.WriteLine($"encryptedText: {encryptedText}");

        }
    }
}
