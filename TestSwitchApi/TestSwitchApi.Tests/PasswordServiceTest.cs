using NUnit.Framework;
using TestSwitchApi.Services;
using FluentAssertions;

namespace TestSwitchApi.Tests
{
    public class PasswordServiceTests
    {
        private PasswordService _passwordService;

        [SetUp]
        public void SetUp()
        {
            _passwordService = new PasswordService();
        }

        [Test]
        public void CheckIsLoginPasswordValid()
        {
            var testPassword = "password123";
            var testSalt = _passwordService.GenerateSalt();
            var testHashedPassword = _passwordService.HashPassword(testPassword, testSalt);
            _passwordService.IsLoginPasswordValid(testPassword, testSalt, testHashedPassword).Should().BeTrue();
        }
    }
}