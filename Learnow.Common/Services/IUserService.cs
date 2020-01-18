using Learnow.Contract.Dto.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Learnow.Common.Services
{
    public interface IUserService
    {
        Task<UserDto> CreateAsync(CreateUserDto createUserDto);
        Task<IEnumerable<UserDto>> ReadAsync();
        Task<UserDto> ReadAsync(long id);
        Task<UserDto> UpdateAsync(UpdateUserDto updateUserDto);
        Task<bool> DeleteAsync(long id);
        Task<UserDto> ReadByUsernameAsync(string username);
    }
}
