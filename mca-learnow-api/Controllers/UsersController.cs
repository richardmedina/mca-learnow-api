using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Learnow.Common.Services;
using Learnow.Contract.Dto.Users;
using Learnow.Contract.Models.Users;
using Learnow.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            var result = await _userService.CreateAsync(dto);

            return result != null
                ? Created($"/users/{result.Id}", _mapper.Map<UserModel>(result)) as IActionResult
                : BadRequest();
        }
        
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Read ()
        {
            var result = await _userService.ReadAsync();

            return Ok (_mapper.Map<IEnumerable<UserModel>> (result));
        }
        
        [HttpGet("{id:long}")]
        public async Task<IActionResult> ReadOne(long id)
        {
            var result = await _userService.ReadAsync(id);
            var currentUserName = JsonConvert.SerializeObject(User.Claims);
            Response.Headers.Add("Currrent Claims", currentUserName);

            if (result != null)
            {
                return Ok(_mapper.Map<UserModel>(result));
            }

            return NotFound();
        }

        //[HttpGet]
        //public async Task<IActionResult> ReadByUsername([FromQuery] string username)
        //{
        //    var result = await _userService.ReadByUsername(username);
        //    if (result != null)
        //    {
        //        return Ok(_mapper.Map<UserModel>(result));
        //    }

        //    return NotFound();
        //}

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateUserRequest request)
        {
            var dto = _mapper.Map<UpdateUserDto>(request);
            dto.Id = id;
            var result = await _userService.UpdateAsync(dto);

            return result != null
                ? Ok(_mapper.Map<UserModel>(result)) as IActionResult
                : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete (long id)
        {
            var result = await _userService.DeleteAsync(id);

            return result
                ? Ok() as IActionResult
                : NotFound();
        }
    }
}