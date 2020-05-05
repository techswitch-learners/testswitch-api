using System;
using System.Net;

namespace TestSwitchApi.Services
{
    public interface ICookieService
    {
        Cookie MakeNewLoginCookie(Guid sessionId, DateTime expires);
    }
}