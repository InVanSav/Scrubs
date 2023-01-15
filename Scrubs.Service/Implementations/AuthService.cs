using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Scrubs.DAL.Interfaces;
using Scrubs.Domain.Entity;
using Scrubs.Domain.Response;
using Scrubs.Domain.Enum;
using Microsoft.AspNetCore.Mvc;
using Scrubs.Domain.HashPasswordHelper;

namespace Scrubs.Service.Interfaces {

    public class AuthService : IAuthService {

        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthService> _logger;

        public AuthService(IUserRepository userRepository,
            ILogger<AuthService> logger) {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<BaseResponse<ClaimsIdentity>> Register(Register register) {

            try {

                var user = await _userRepository.GetByFullName(register.Name);

                if (user != null) {
                    return new BaseResponse<ClaimsIdentity>() {
                        Result = "Данный пользователь уже зарегестрирован"
                    };
                }

                user = new User() {
                    FullName = register.Name,
                    Role = "User",
                    Password = HashPasswordHelper.HashPassword(register.Password),
                };

                await _userRepository.Create(user);
                var result = Authenticate(user);

                return new BaseResponse<ClaimsIdentity>() {
                    Data = result,
                    Result = "Объект добавлен",
                    StatusCode = StatusCode.OK,
                };

            } catch (Exception ex) {

                _logger.LogError(ex, $"[Register]: {ex.Message}");
                return new BaseResponse<ClaimsIdentity>() {
                    Result = ex.Message,
                    StatusCode = StatusCode.InternalServerError,
                };

            }

        }

        public async Task<BaseResponse<string>> Login(Login login) {

            try {

                var user = await _userRepository.GetByFullName(login.Name);

                if (user == null) {
                    return new BaseResponse<string>() {
                        Result = "Данный пользователь не найден"
                    };
                }

                if (user.Password != HashPasswordHelper.HashPassword(login.Password)) {
                    return new BaseResponse<string>() {
                        Result = "Неверный пароль"
                    };
                }

                var result = Authenticate(user);
                var token = CreateToken(login);

                return new BaseResponse<string>()
                {

                    Data = token,
                    StatusCode = StatusCode.OK,

                };

            } catch (Exception ex) {

                _logger.LogError(ex, $"[Login]: {ex.Message}");
                return new BaseResponse<string>() {
                    Result = ex.Message,
                    StatusCode = StatusCode.InternalServerError,
                };

            }

        }

        private ClaimsIdentity Authenticate(User user) {

            var claims = new List<Claim>() {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.FullName),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role),
            };

            return new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }

        private string CreateToken(Login user) {

            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.Name)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                    _configuration.GetSection("AppSettings:Token").Value)
                );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;

        }
    }

}

