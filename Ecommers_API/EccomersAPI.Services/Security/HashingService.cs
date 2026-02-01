using EccomersAPI.DataAbstraction.Security;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.Services.Security
{
    public class HashingService : IHashingService
    {
        public string GenerateSalt()
        {
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
            return Convert.ToBase64String(salt);
        }

        public string HashPassword(string password,string salt)
        {

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password!,
                salt: Encoding.UTF8.GetBytes(salt),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            return hashed;
        }
        public bool VerifyPassword(string originalPassword, string passwordHashed, string salt)
        {
            string hashedPassword = this.HashPassword(originalPassword, salt);
            return (hashedPassword.Equals(passwordHashed));

        }
    }
}
