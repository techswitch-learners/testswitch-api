using System;
using System.Net;
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
                 Domain = "https://testswitch-admin-staging.herokuapp.com",
                 HttpOnly = false,
                 Secure = true,
                 SameSite = SameSiteMode.Lax,
             };
             context.Response.Cookies.Append("sessionId", sessionId.ToString(), cookieOptions);
         }
     }
}