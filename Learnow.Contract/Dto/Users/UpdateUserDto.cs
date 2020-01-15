using System;
using System.Collections.Generic;
using System.Text;

namespace Learnow.Contract.Dto.Users
{
    public class UpdateUserDto
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
