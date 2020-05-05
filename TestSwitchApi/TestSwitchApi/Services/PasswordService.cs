using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace TestSwitchApi.Services
{
    public class PasswordService : IPasswordService
    {
        public byte[] GenerateSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }

        public string HashPassword(string password, byte[] salt)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 5000,
                numBytesRequested: 256 / 8));
            return hashed;
        }

        public bool IsLoginPasswordValid(string passwordInput, byte[] saltToBeCompared, string hashedPasswordToBeCompared)
        {
            var hashedPasswordInput = HashPassword(passwordInput, saltToBeCompared);
            return hashedPasswordInput == hashedPasswordToBeCompared;
        }
    }
}