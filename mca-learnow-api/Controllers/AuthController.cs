using AutoMapper;
using Learnow.Common.Services;
using Learnow.Contract.Models.Security;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mca_learnow_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;
        public AuthController(IMapper mapper, IAuthService authService)
        {
            _mapper = mapper;
            _authService = authService;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateRequest request)
        {
            var result = await _authService.AuthenticateAsync(request.Username, request.Password);

            return result != null
                ? Ok(_mapper.Map<AuthenticateResponse>(result)) as IActionResult
                : Unauthorized();
        }
    }
}
