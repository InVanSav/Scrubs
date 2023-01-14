using System;
using Microsoft.AspNetCore.Mvc;
using Scrubs.Domain.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Scrubs.Service.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Scrubs.API.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService) {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> UserRegister(Register register) {

            var response = await _authService.Register(register);

            if (response.StatusCode == Domain.Enum.StatusCode.OK) {

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(response.Data));

                return Ok("Регистрация прошла успешно");

            }

            return BadRequest(register);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(Login login) {

            var response = await _authService.Login(login);

            if (response.StatusCode == Domain.Enum.StatusCode.OK) {

                //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                //    new ClaimsPrincipal(response.Data));

                return Ok("Авторизация прошла успешно");

            }

            return BadRequest(login);
        }

    }

}

