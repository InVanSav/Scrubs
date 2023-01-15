using System;

using Microsoft.AspNetCore.Mvc;
using Scrubs.Service.Interfaces;


namespace Scrubs.API.Controllers {

    [ApiController]
    [Route("api/user/[controller]")]
    public class HttpGetUser : ControllerBase {

        private readonly IUserService _userService;

        public HttpGetUser(IUserService userService) {
            _userService = userService;
        }

        [HttpGet("get-users")]
        public async Task<IActionResult> GetUsers() {

            var response = await _userService.GetUsers();

            if (response.Result == "Users not found:(") {
                return BadRequest("Ничего не найдено");
            }

            if (response.StatusCode == Domain.Enum.StatusCode.OK) {
                return Ok(response.Data);
            }

            return NoContent();
        }

        [HttpGet("get-user/{id}")]
        public async Task<IActionResult> GetUser(int id) {

            var response = await _userService.Get(id);

            if (response.Result == "User not found:(") {
                return BadRequest("Ничего не найдено");
            }

            if (response.StatusCode == Domain.Enum.StatusCode.OK) {
                return Ok(response.Data);
            }

            return NoContent();

        }

        [HttpGet("get-user-by-phone/{phone}")]
        public async Task<IActionResult> GetByPhoneNumber(int phone) {

            var response = await _userService.GetByPhoneNumber(phone);

            if (response.Result == "User not found:(") {
                return BadRequest("Ничего не найдено");
            }

            if (response.StatusCode == Domain.Enum.StatusCode.OK) {
                return Ok(response.Data);
            }

            return NoContent();

        }

        [HttpGet("get-user-by-role/{role}")]
        public async Task<IActionResult> GetByRole(string role) {

            var response = await _userService.GetByRole(role);

            if (response.Result == "User not found:(") {
                return BadRequest("Ничего не найдено");
            }

            if (response.StatusCode == Domain.Enum.StatusCode.OK) {
                return Ok(response.Data);
            }

            return NoContent();

        }

        [HttpGet("get-user-by-password/{password}")]
        public async Task<IActionResult> GetByPassword(string password) {

            var response = await _userService.GetByPassword(password);

            if (response.Result == "User not found:(") {
                return BadRequest("Ничего не найдено");
            }

            if (response.StatusCode == Domain.Enum.StatusCode.OK) {
                return Ok(response.Data);
            }

            return NoContent();

        }

        [HttpGet("get-user-by-fullname/{fullname}")]
        public async Task<IActionResult> GetByName(string fullName) {

            var response = await _userService.GetByName(fullName);

            if (response.Result == "User not found:(") {
                return BadRequest("Ничего не найдено");
            }

            if (response.StatusCode == Domain.Enum.StatusCode.OK) {
                return Ok(response.Data);
            }

            return NoContent();

        }

    }
}

