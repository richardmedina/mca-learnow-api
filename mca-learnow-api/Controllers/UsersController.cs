using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Learnow.Common.Services;
using Learnow.Contract.Dto.Users;
using Learnow.Contract.Models.Users;
using Learnow.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mca_learnow_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UsersController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest createUserRequest)
        {
            var dto = _mapper.Map<CreateUserDto>(createUserRequest);
            var result = await _userService.Create(dto);

            return Created($"/users/{result.Id}","hola");
        }

        [HttpGet]
        public async Task<IEnumerable<UserModel>> Read ()
        {
            var result = await _userService.GetAll();

            return _mapper.Map<IEnumerable<UserModel>> (result);
        }
    }
}