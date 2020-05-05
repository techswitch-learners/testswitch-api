using System;
using System.Net;

namespace TestSwitchApi.Services
{
    public class CookieService : ICookieService
    {
        public Cookie MakeNewLoginCookie(Guid sessionId, DateTime expires)
        {
            throw new NotImplementedException();
        }
    }
}