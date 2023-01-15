using System;
using Scrubs.Domain.Entity;
using Scrubs.Domain.Response;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Scrubs.Service.Interfaces {

    public interface IAuthService {

        Task<BaseResponse<ClaimsIdentity>> Register(Register register);

        Task<BaseResponse<string>> Login(Login login);

    }

}
