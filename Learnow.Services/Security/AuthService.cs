using Learnow.Common.Services;
using Learnow.Contract.Dto.Security;
using Learnow.Infrastructure.Jwt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Learnow.Services.Security
{
    public class AuthService : IAuthService
    {
        private readonly IJwtHandler _jwtHandler;
        private readonly IUserService _userService;
        public AuthService(IJwtHandler jwtHandler, IUserService userService)
        {
            _jwtHandler = jwtHandler;
            _userService = userService;
        }
        public async Task<AuthTokenDto> AuthenticateAsync(string username, string password)
        {
            var user = await _userService.ReadByUsernameAsync(username);

            if (user != null && username == user.Username && password == user.Password)
            {
                return _jwtHandler.Create(username);
            }

            return null;
        }
    }
}
