using Learnow.Contract.Dto.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace Learnow.Infrastructure.Jwt
{
    public interface IJwtHandler
    {
        public AuthTokenDto Create(string username);
    }
}
