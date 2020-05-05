using System;
using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace TestSwitchApi.Services
{
     public class CookieService : ICookieService
     {
         public void MakeNewLoginCookie(Guid sessionId, HttpContext context)
         {
             var cookieOptions = new CookieOptions
             {
                 Expires = new DateTimeOffset(DateTime.Now.AddDays(1)),
                 Domain = Environment.GetEnvironmentVariable("FRONT_END_URL"),
                 HttpOnly = false,
                 Secure = true,
                 SameSite = SameSiteMode.Lax,
             };
             context.Response.Cookies.Append("sessionId", sessionId.ToString(), cookieOptions);
         }
     }
}