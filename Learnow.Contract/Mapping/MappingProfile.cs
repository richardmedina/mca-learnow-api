using AutoMapper;
using Learnow.Contract.Dto.Security;
using Learnow.Contract.Dto.Users;
using Learnow.Contract.Models.Security;
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
            CreateSecurityMaps();
        }

        private void CreateUserMaps ()
        {
            CreateMap<CreateUserRequest, CreateUserDto>();
            CreateMap<UpdateUserRequest, UpdateUserDto>();
            CreateMap<UserDto, UserModel>();
            CreateMap<UserEntity, UserDto>();
        }

        private void CreateSecurityMaps ()
        {
            CreateMap<AuthTokenDto, AuthenticateResponse>();
        }

        private DateTime ConvertLongToDateTime (long unixDate)
        {
            //long unixDate = 1297380023295;
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return start.AddMilliseconds(unixDate).ToLocalTime();
        }
    }
}
