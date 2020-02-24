using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Learnow.Common.Services;
using Learnow.Contract.Dto.Users;
using Learnow.Domain;
using Learnow.Domain.Entities;
using Learnow.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Learnow.Services.User
{
    public class UserService : ServiceBase, IUserService
    {
        private readonly IMapper _mapper;

        public UserService(AppDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<UserDto> CreateAsync(CreateUserDto createUserDto)
        {
            throw new NotImplementedException();
            //var createdUser = await Context.Users.AddAsync(new UserEntity
            //{
            //    Username = createUserDto.Username,
            //    Password = createUserDto.Password
            //});

            //var records = await Context.SaveChangesAsync();


            //return records > 0
            //    ? _mapper.Map<UserDto>(createdUser.Entity)
            //    : null;
        }

        public async Task<IEnumerable<UserDto>> ReadAsync()
        {
            //return _mapper.Map<IEnumerable<UserDto>>(await Context.Users.ToListAsync());
            throw new NotImplementedException();
        }

        public async Task<UserDto> ReadAsync (long id)
        {
            //return _mapper.Map<UserDto>(await Context.Users.FirstOrDefaultAsync(u => u.Id == id));
            throw new NotImplementedException();
        }

        public async Task<UserDto> ReadByUsernameAsync(string username)
        {
            //return _mapper.Map<UserDto>(await Context.Users.FirstOrDefaultAsync(u => u.Username == username));
            throw new NotImplementedException();
        }

        public async Task<UserDto> UpdateAsync(UpdateUserDto updateUserDto)
        {
            //var succeed = false;
            //var user = await Context.Users.FirstOrDefaultAsync(u => u.Id == updateUserDto.Id);
            //if(user != null)
            //{
            //    user.Username = string.IsNullOrWhiteSpace(updateUserDto.Username)
            //        ? user.Username
            //        : updateUserDto.Username;

            //    user.Password = string.IsNullOrWhiteSpace(updateUserDto.Password)
            //        ? user.Password
            //        : updateUserDto.Password;

            //    succeed = await Context.SaveChangesAsync() > 0;
            //}

            //return succeed
            //    ? _mapper.Map<UserDto>(user)
            //    : null;
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync (long id)
        {
            //var user = await Context.Users.FirstOrDefaultAsync(u => u.Id == id);

            //if (user != null)
            //{
            //    Context.Users.Remove(user);
            //    return await Context.SaveChangesAsync() > 0;
            //}

            //return false;
            throw new NotImplementedException();
        }
    }
}
