using System.Net;
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
        private readonly ICookieService _cookieService;

        public AdminSigninController(IAdminRepo adminRepo, IPasswordService passwordService, ICookieService cookieService)
        {
            _adminRepo = adminRepo;
            _passwordService = passwordService;
            _cookieService = cookieService;
        }

        [HttpPost("")]
        public ActionResult<Cookie> AttemptLogin([FromForm] LoginRequest loginRequest)
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
            var cookieResponse = _cookieService.MakeNewLoginCookie(newSession.Id, newSession.SessionEnd);
            return cookieResponse;
        }
    }
}