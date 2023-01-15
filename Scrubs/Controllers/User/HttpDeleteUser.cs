using System;

using Microsoft.AspNetCore.Mvc;
using Scrubs.Service.Implementations;
using Scrubs.Service.Interfaces;

namespace Scrubs.API.Controllers {

    [ApiController]
    [Route("api/user/[controller]")]
    public class HttpDeleteUser : ControllerBase {

        private readonly IUserService _userService;

        public HttpDeleteUser(IUserService userService) {
            _userService = userService;
        }

        [HttpDelete("delete-user/{id}")]
        public async Task<IActionResult> DeleteUser(int id) {

            if (id == null) {
                return BadRequest("Запрос должен включать id");
            }

            var response = await _userService.DeleteUser(id);

            if (response.StatusCode == Domain.Enum.StatusCode.OK) {
                return Ok("Объект user успешно удален");
            }

            return BadRequest("Не получилось удалить объект user");

        }

    }

}

