using System;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace TestSwitchApi.Services
{
    public interface ICookieService
    {
        void MakeNewLoginCookie(Guid sessionId, HttpContext context);
    }
}