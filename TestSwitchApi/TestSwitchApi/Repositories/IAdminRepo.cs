using TestSwitchApi.Models.DataModels;

namespace TestSwitchApi.Repositories
{
    public interface IAdminRepo
    {
        AdminUserDataModel GetAdminByEmail(string email);
    }
}