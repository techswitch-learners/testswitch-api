namespace TestSwitchApi.Services
{
    public interface IPasswordService
    {
        string GenerateSalt();
        string HashPassword(string password, string salt);
        bool IsLoginPasswordValid(string passwordInput, string saltToBeCompared, string hashedPasswordsaltToBeCompared);
    }
}