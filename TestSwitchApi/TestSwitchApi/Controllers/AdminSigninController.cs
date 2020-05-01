using Microsoft.AspNetCore.Mvc;
using TestSwitchApi.Models.Request;
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
        public ActionResult<string> AttemptLogin([FromForm] LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var adminUser = _adminRepo.GetAdminByEmail(loginRequest.Email);
            if (adminUser == null)
            {
                return Unauthorized();
            }

            var passwordValid =
                _passwordService.IsLoginPasswordValid(loginRequest.Password, adminUser.PasswordSalt, adminUser.HashedPassword);
            if (!passwordValid)
            {
                return Unauthorized();
            }

            var newSession = _adminRepo.CreateAndStoreSession(adminUser.Id);
            if (newSession == null)
            {
                return Unauthorized("Database error");
            }

            return newSession.Id;
        }
    }
}