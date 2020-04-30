using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestSwitchApi.Models.DataModels;
using TestSwitchApi.Repositories;

namespace TestSwitchApi.Controllers
{
    [ApiController]
    [Route("/sign-in")]
    public class AdminSigninController : Controller
    {
        private readonly IAdminRepo _adminRepo;
        public AdminSigninController(IAdminRepo adminRepo)
        {
            _adminRepo = adminRepo;
        }

        [HttpPost("")]
        public ActionResult<string> AttemptLogin([FromForm] string email, string password)
        {
            //test if exists in DB
            //--if not then return 403 response
            var adminUser = _adminRepo.GetAdminByEmail(email);
            if (adminUser == null)
            {
                return Unauthorized();
            }

            var passwordValid = _adminRepo.IsLoginPasswordValid(password, adminUser.PasswordSalt, adminUser.HashedPassword);
            var sessionId = " ";
            return sessionId;
        }

        [HttpPost("test")]
        public AdminUserDataModel CheckEmailExists([FromForm] string email)
        {
            return _adminRepo.GetAdminByEmail(email);
        }
    }
}