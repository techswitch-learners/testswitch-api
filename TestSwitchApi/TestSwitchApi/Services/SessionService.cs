using System;
using Microsoft.AspNetCore.Http;
using TestSwitchApi.Repositories;

namespace TestSwitchApi.Services
{
    public class SessionService : ISessionService
    {
        public bool SessionInDate(DateTime SessionEndTime)
        {
            return SessionEndTime > DateTime.Now ? true : false;
        }

        public bool RequestHasValidSessionId(HttpContext context, IAdminRepo adminRepo)
        {
            if (!context.Request.Headers.ContainsKey("Session-Id"))
            {
                return false;
            }

            var sessionId = context.Request.Headers["Session-Id"];
            var session = adminRepo.GetSession(sessionId);
            if (session == null)
            {
                return false;
            }

            if (!SessionInDate(session.SessionEnd))
            {
                return false;
            }

            return true;
        }
    }
}