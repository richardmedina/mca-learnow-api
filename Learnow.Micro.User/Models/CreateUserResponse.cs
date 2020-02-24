using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learnow.Micro.User.Models
{
    public class CreateUserResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Passwrod { get; set; }
    }
}
