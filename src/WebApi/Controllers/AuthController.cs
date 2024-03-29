﻿using Application.Features.Auth.Commands;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class AuthController : BaseApiController
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
