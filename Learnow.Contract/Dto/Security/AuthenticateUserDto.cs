using System;
using System.Collections.Generic;
using System.Text;

namespace Learnow.Contract.Dto.Security
{
    public class AuthenticateUserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
