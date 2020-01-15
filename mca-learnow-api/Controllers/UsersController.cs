﻿using System;
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

            return result != null
                ? Created($"/users/{result.Id}", _mapper.Map<UserModel>(result)) as IActionResult
                : BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> Read ()
        {
            var result = await _userService.Read();

            return Ok (_mapper.Map<IEnumerable<UserModel>> (result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ReadOne(long id)
        {
            var result = await _userService.Read(id);

            if (result != null)
            {
                return Ok(_mapper.Map<UserModel>(result));
            }

            return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserRequest request)
        {
            var dto = _mapper.Map<UpdateUserDto>(request);

            var result = await _userService.Update(dto);

            return result != null
                ? Ok(_mapper.Map<UserModel>(result)) as IActionResult
                : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete (long id)
        {
            var result = await _userService.Delete(id);

            return result
                ? Ok() as IActionResult
                : NotFound();
        }
    }
}