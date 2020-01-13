using System;
using System.Collections.Generic;
using System.Text;

namespace Learnow.Contract.Models.Users
{
    public class CreateUserRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
