﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class RegisterAccountModel : Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
