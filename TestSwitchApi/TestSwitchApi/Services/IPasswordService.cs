namespace TestSwitchApi.Services
{
    public interface IPasswordService
    {
        byte[] GenerateSalt();
        string HashPassword(string password, byte[] salt);
        bool IsLoginPasswordValid(string passwordInput, byte[] saltToBeCompared, string hashedPasswordsaltToBeCompared);
    }
}