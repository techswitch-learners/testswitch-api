using System;
using System.Linq;
using TestSwitchApi.Models.ApiModels;
using TestSwitchApi.Models.DataModels;
using TestSwitchApi.Services;

namespace TestSwitchApi.Repositories
{
    public class AdminRepo : IAdminRepo
    {
        private readonly TestSwitchDbContext _context;
        private readonly IPasswordService _passwordService = new PasswordService();

        public AdminRepo(TestSwitchDbContext context)
        {
            _context = context;
        }

        public void CreateNewAdminUser(string email, string password)
        {
            var salt = _passwordService.GenerateSalt();
            var newAdminUser = new AdminUserDataModel()
            {
                Email = email,
                PasswordSalt = salt,
                HashedPassword = _passwordService.HashPassword(password, salt),
            };
            _context.AdminUsers.Add(newAdminUser);
            _context.SaveChanges();
        }

        public AdminUserDataModel GetAdminByEmail(string email)
        {
            return _context.AdminUsers.SingleOrDefault(adminUsers => adminUsers.Email == email.ToLower());
        }

        public AdminUserSession CreateAndStoreSession(int adminUserId)
        {
            var newSession = new AdminUserSession
                { Id = Guid.NewGuid(), AdminUserID = adminUserId };
            _context.AdminUserSessions.Add(newSession);
            _context.SaveChanges();
            return _context.AdminUserSessions.SingleOrDefault(s => s.Id == newSession.Id);
        }

        public AdminUserSession GetSession(string sessionId)
        {
            return _context.AdminUserSessions.SingleOrDefault(s=>s.Id.ToString() == sessionId);
        }
    }
}