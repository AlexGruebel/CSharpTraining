using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;
namespace CryptographyLib{
    public class User
    {
        public string Name {get; set;}
        public string Salt {get; set;}

        public string SaltedHashedPassword { get; set; }

        private static Dictionary<string, User> Users = new Dictionary<string, User>();    

        public static User Register(string username, string pw){
            var rng = RandomNumberGenerator.Create();
            var saltBytes = new byte[16];
            rng.GetBytes(saltBytes);
            var saltText = Convert.ToBase64String(saltBytes);

            //generate the salt and hashed password
            var sha = SHA256.Create();
            var saltetPasswort = pw + saltText;
            var saltedHashedPassword = Convert.ToBase64String(sha.ComputeHash(Encoding.Unicode.GetBytes(saltetPasswort)));

            var user = new User
            {
                Name = username,
                Salt = saltText,
                SaltedHashedPassword = saltedHashedPassword
            };
            Users.Add(user.Name, user);
            return user;
        }

        public static bool CheckPassword(string username, string password)
        {
            if(!Users.ContainsKey(username)){
                return false;
            }

            var user = Users[username];
            var sha = SHA256.Create();
            var saltetPasswort = password +  user.Salt;
            var saltedHashedPassword = Convert.ToBase64String(sha.ComputeHash(Encoding.Unicode.GetBytes(saltetPasswort)));
            return (saltedHashedPassword == user.SaltedHashedPassword);
        }
    }
}