using System;
using System.Collections.Generic;
using System.Text;

namespace Learnow.Contract.Models.Security
{
    public class AuthenticateRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
