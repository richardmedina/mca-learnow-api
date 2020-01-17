using System;
using System.Collections.Generic;
using System.Text;

namespace Learnow.Contract.Models.Security
{
    public class AuthenticateResponse
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
    }
}
