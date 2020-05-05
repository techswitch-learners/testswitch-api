using System;

namespace TestSwitchApi.Services
{
    public interface ISessionService
    {
        public bool IsValidSession(DateTime SessionEndTime);
    }
}