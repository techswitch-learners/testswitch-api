namespace TestSwitchApi.Repositories
{
    public interface IAdminRepo
    {
        string GenerateSalt();
        string HashPassword(string password, string salt);
    }
}