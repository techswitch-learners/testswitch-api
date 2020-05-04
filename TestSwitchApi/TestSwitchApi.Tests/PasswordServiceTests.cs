using System.Text;
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
        public void CheckSaltIsCorrectLength()
        {
            byte[] testSalt = _passwordService.GenerateSalt();
            testSalt.Should().HaveCount(16);
        }

        [Test]
        public void CheckHashedPasswordIsCorrectLength()
        {
            string testPassword = "hereIsANiceTestPassword!$%";
            _passwordService.HashPassword(
                    testPassword,
                    _passwordService.GenerateSalt())
                .Should()
                .HaveLength(44);
        }

        [Test]
        public void CheckIsLoginPasswordValid()
        {
            var testPassword = "hereIsAnotherNicerTestPassword!$%";
            var testSalt = _passwordService.GenerateSalt();
            var testHashedPassword = _passwordService.HashPassword(testPassword, testSalt);
            _passwordService
                .IsLoginPasswordValid(testPassword, testSalt, testHashedPassword)
                .Should()
                .BeTrue();
        }
    }
}