using System.Text;
using NUnit.Framework;
using TestSwitchApi.Services;
using FluentAssertions;

namespace TestSwitchApi.Tests
{
    public class PasswordServiceTests
    {
        private PasswordService _passwordService;

        private string GenerateRandomPassword(
            int size = 15,
            string allowedCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890")
        {
            char[] chars = allowedCharacters.ToCharArray();
            var crypto = System.Security.Cryptography.RandomNumberGenerator.Create();
            byte[] data = new byte[size];
            crypto.GetBytes(data);
            var result = new StringBuilder(size);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length - 1)]);
            }

            return result.ToString();
        }

        [SetUp]
        public void SetUp()
        {
            _passwordService = new PasswordService();
        }

        [Test]
        public void CheckSaltIsCorrectLength()
        {
            _passwordService
                .GenerateSalt()
                .Should()
                .HaveLength(24);
        }

        [Test]
        public void CheckHashedPasswordIsCorrectLength()
        {
            _passwordService.HashPassword(
                    GenerateRandomPassword(),
                    _passwordService.GenerateSalt())
                .Should()
                .HaveLength(44);
        }

        [Test]
        public void CheckIsLoginPasswordValid()
        {
            var testPassword = GenerateRandomPassword();
            var testSalt = _passwordService.GenerateSalt();
            var testHashedPassword = _passwordService.HashPassword(testPassword, testSalt);
            _passwordService
                .IsLoginPasswordValid(testPassword, testSalt, testHashedPassword)
                .Should()
                .BeTrue();
        }
    }
}