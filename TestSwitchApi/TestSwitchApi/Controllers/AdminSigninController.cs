using Microsoft.AspNetCore.Mvc;
using TestSwitchApi.Repositories;
using TestSwitchApi.Services;

namespace TestSwitchApi.Controllers
{
    [ApiController]
    [Route("/sign-in")]
    public class AdminSigninController : Controller
    {
        private readonly IAdminRepo _adminRepo;
        private readonly IPasswordService _passwordService;

        public AdminSigninController(IAdminRepo adminRepo, IPasswordService passwordService)
        {
            _adminRepo = adminRepo;
            _passwordService = passwordService;
        }

        [HttpPost("")]
        public ActionResult<string> AttemptLogin([FromForm] string email, [FromForm] string password)
        {
            var adminUser = _adminRepo.GetAdminByEmail(email);
            if (adminUser == null)
            {
                return Unauthorized();
            }

            var passwordValid =
                _passwordService.IsLoginPasswordValid(password, adminUser.PasswordSalt, adminUser.HashedPassword);
            if (!passwordValid)
            {
                return Unauthorized();
            }

            return "Valid Email and Password";
        }
    }
}