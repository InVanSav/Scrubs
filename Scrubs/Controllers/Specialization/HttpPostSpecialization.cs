using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Scrubs.Domain.Entity;
using Scrubs.Service.Implementations;
using Scrubs.Service.Interfaces;

namespace Scrubs.API.Controllers {

    [ApiController]
    [Route("api/specisalisation/[controller]")]
    public class HttpPostSpecialization : ControllerBase {

        private readonly ISpecializationService _specializationService;

        public HttpPostSpecialization(ISpecializationService specializationService) {
            _specializationService = specializationService;
        }

        [HttpPost("create-specialization")]
        [Authorize]
        public async Task<IActionResult> CreateSpecialization(Specialization specialization) {

            if (specialization == null) {
                return BadRequest("Запрос должен включать specialization");
            }

            var response = await _specializationService.CreateSpecialization(specialization);

            if (response.StatusCode == Domain.Enum.StatusCode.OK) {
                return Ok("Объект specialization успешно создан");
            }

            return BadRequest("Не получилось создать объект specialization");

        }

    }
}
