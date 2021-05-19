using System;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace BLL.Services
{
    public class PasswordHasher
    {
        public string HashPassword(string passwordToHash)
        {
            if (passwordToHash == null)
                throw new Exception("Password is empty");
            byte[] salt = new byte[4];
            var keyDerivation = KeyDerivationPrf.HMACSHA1;
            int iterationCount = 10000;
            int hashedPasswordLength = 8;
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(passwordToHash, salt, keyDerivation, iterationCount, hashedPasswordLength));
            return hashed;
        }
    }
}
