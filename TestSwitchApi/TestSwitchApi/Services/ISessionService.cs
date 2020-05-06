﻿using System;
using Microsoft.AspNetCore.Http;
using TestSwitchApi.Repositories;

namespace TestSwitchApi.Services
{
    public interface ISessionService
    {
        public bool SessionInDate(DateTime SessionEndTime);
        public bool RequestHasValidSessionId(HttpContext context, IAdminRepo adminRepo);
    }
}