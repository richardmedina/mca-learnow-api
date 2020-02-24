using Learnow.Micro.User.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learnow.Micro.User.Commands
{
    public class CreateUserCommand : IRequest<CreateUserResponse>
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Passwrod { get; set; }
    }
}
