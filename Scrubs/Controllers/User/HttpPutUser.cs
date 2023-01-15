using System;

using Microsoft.AspNetCore.Mvc;
using Scrubs.Domain.Entity;
using Scrubs.Service.Implementations;
using Scrubs.Service.Interfaces;

namespace Scrubs.API.Controllers {

    [ApiController]
    [Route("api/user/[controller]")]
    public class HttpPutUser : ControllerBase {

        private readonly IUserService _userService;

        public HttpPutUser(IUserService userService) {
            _userService = userService;
        }

        [HttpPut("edit-user/{id}")]
        public async Task<IActionResult> EditTimeTable(int id, User user) {

            if (id == null || user == null) {
                return BadRequest("Запрос должен включать user");
            }

            var response = await _userService.Edit(id, user);

            if (response.StatusCode == Domain.Enum.StatusCode.OK) {
                return Ok("Объект user успешно отредактирован");
            }

            return BadRequest("Не получилось отредактировать объект user");

        }

    }
}

