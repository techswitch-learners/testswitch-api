using System;
using System.Linq;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using TestSwitchApi.Models.ApiModels;
using TestSwitchApi.Models.DataModels;

namespace TestSwitchApi.Repositories
{
    public class AdminRepo : IAdminRepo
    {
        private readonly TestSwitchDbContext _context;

        public AdminRepo(TestSwitchDbContext context)
        {
            _context = context;
        }

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

        public AdminUserDataModel GetAdminByEmail(string email)
        {
            return _context.AdminUsers.SingleOrDefault(c => c.Email == email);
        }

        public bool IsLoginPasswordValid(string passwordInput, string databaseSalt, string databaseHashedPassword)
        {
            var hashedPasswordInput = HashPassword(passwordInput, databaseSalt);
            return hashedPasswordInput == databaseHashedPassword;
        }
    }
}