using System;
using System.Collections.Generic;
using System.Text;

namespace Learnow.Contract.Dto.Security
{
    public class AuthTokenDto
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
    }
}
