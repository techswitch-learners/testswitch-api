﻿using System;
using System.ComponentModel.DataAnnotations;

namespace TestSwitchApi.Models.DataModels
{
    public class AdminUserSession
    {
        [Key]
        public Guid Id { get; set; }
        public int AdminUserID { get; set; }
        public DateTime SessionStart { get; set; }
        public DateTime SessionEnd { get; set; }

        public AdminUserSession()
        {
            SessionStart = DateTime.Now;
            SessionEnd = DateTime.Now.AddDays(1);
        }
    }
}