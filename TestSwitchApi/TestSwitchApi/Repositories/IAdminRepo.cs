using TestSwitchApi.Models.DataModels;

namespace TestSwitchApi.Repositories
{
    public interface IAdminRepo
    {
        void CreateNewAdminUser(string email, string password);
        AdminUserDataModel GetAdminByEmail(string email);
        AdminUserSession CreateAndStoreSession(int adminId);
    }
}