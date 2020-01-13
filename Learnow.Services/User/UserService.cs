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
using Microsoft.EntityFrameworkCore;

namespace Learnow.Services.User
{
    public class UserService : ServiceBase, IUserService
    {
        private readonly IMapper _mapper;

        public UserService(LearnowDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<UserDto> Create(CreateUserDto createUserDto)
        {
            var createdUser = await Context.Users.AddAsync(new UserEntity
            {
                Username = createUserDto.Username,
                Password = createUserDto.Password
            });

            await Context.SaveChangesAsync();

            return _mapper.Map<UserDto>(createdUser.Entity);
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<UserDto>>(await Context.Users.ToListAsync());
        }
    }
}
