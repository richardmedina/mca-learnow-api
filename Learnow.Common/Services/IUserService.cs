using Learnow.Contract.Dto.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Learnow.Common.Services
{
    public interface IUserService
    {
        Task<UserDto> Create(CreateUserDto createUserDto);
        Task<IEnumerable<UserDto>> GetAll();
    }
}
