using TestSwitchApi.Models.DataModels;

namespace TestSwitchApi.Repositories
{
    public interface IAdminRepo
    {
        string GenerateSalt();
        string HashPassword(string password, string salt);
        bool IsLoginPasswordValid(string password, string databaseSalt, string databaseHashedPassword);
        AdminUserDataModel GetAdminByEmail(string email);
    }
}