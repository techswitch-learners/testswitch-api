using System;

namespace TestSwitchApi.Services
{
    public class SessionService : ISessionService
    {
        public bool IsValidSession(DateTime SessionEndTime)
        {
            return SessionEndTime > DateTime.Now ? true : false;
        }
    }
}