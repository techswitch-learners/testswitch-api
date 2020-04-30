using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace TestSwitchApi.Services
{
    public class PasswordService : IPasswordService
    {
        public string GenerateSalt()
        {
            byte[] saltBytes = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }

            string salt = Convert.ToBase64String(saltBytes);
            return salt;
        }

        public string HashPassword(string password, string salt)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Convert.FromBase64String(salt),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 5000,
                numBytesRequested: 256 / 8));
            return hashed;
        }

        public bool IsLoginPasswordValid(string passwordInput, string saltToBeCompared, string hashedPasswordToBeCompared)
        {
            var hashedPasswordInput = HashPassword(passwordInput, saltToBeCompared);
            return hashedPasswordInput == hashedPasswordToBeCompared;
        }
    }
}