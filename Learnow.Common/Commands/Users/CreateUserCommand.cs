using System;
using System.Collections.Generic;
using System.Text;

namespace Learnow.Common.Commands.Users
{
    public class CreateUserCommand : ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
