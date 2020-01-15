using AutoMapper;
using Learnow.Contract.Dto.Users;
using Learnow.Contract.Models.Users;
using Learnow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Learnow.Contract.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateUserMaps();
        }

        private void CreateUserMaps ()
        {
            CreateMap<CreateUserRequest, CreateUserDto>();
            CreateMap<UpdateUserRequest, UpdateUserDto>();
            CreateMap<UserDto, UserModel>();
            CreateMap<UserEntity, UserDto>();
        }
    }
}
