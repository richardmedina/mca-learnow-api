using System;
using System.Collections.Generic;
using System.Text;

namespace Learnow.Contract.Dto.Users
{
    public class UserDto
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
