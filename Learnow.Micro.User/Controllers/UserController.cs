using Learnow.Micro.User.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learnow.Micro.User.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController: ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Get ()
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get (long id)
        {
            await Task.CompletedTask;
            return Ok();
        }

        public async Task<IActionResult> Post (CreateUserRequest createUserRequest)
        {
            await Task.CompletedTask;
            return Ok();
        }
    }
}
