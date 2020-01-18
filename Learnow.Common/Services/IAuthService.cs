using Learnow.Contract.Dto.Security;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Learnow.Common.Services
{
    public interface IAuthService
    {
        Task<AuthTokenDto> AuthenticateAsync(string username, string password);
    }
}
