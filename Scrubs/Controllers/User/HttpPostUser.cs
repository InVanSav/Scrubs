using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Scrubs.Domain.Entity;
using Scrubs.Service.Implementations;
using Scrubs.Service.Interfaces;

namespace Scrubs.API.Controllers {

    [ApiController]
    [Route("api/user/[controller]")]
    public class HttpPostUser : ControllerBase {

        private readonly IUserService _userService;

        public HttpPostUser(IUserService userService) {
            _userService = userService;
        }

        [HttpPost("create-user/{id}")]
        [Authorize]
        public async Task<IActionResult> CreateUser(User user) {

            if (user == null) {
                return BadRequest("Запрос должен включать user");
            }

            var response = await _userService.CreateUser(user);

            if (response.StatusCode == Domain.Enum.StatusCode.OK) {
                return Ok(response.Data);
            }

            return NoContent();

        }

    }

}

