using System;

using Microsoft.AspNetCore.Mvc;
using Scrubs.Domain.Entity;
using Scrubs.Service.Implementations;
using Scrubs.Service.Interfaces;

namespace Scrubs.API.Controllers {

    [ApiController]
    [Route("api/specisalisation/[controller]")]
    public class HttpPutSpecialization : ControllerBase {

        private readonly ISpecializationService _specializationService;

        public HttpPutSpecialization(ISpecializationService specializationService) {
            _specializationService = specializationService;
        }

        [HttpPut("edit-specialization/{id}")]
        public async Task<IActionResult> EditSpecialization(int id, Specialization specialization) {

            if (id == null || specialization == null) {
                return BadRequest("Запрос должен включать specialization");
            }

            var response = await _specializationService.Edit(id, specialization);

            if (response.StatusCode == Domain.Enum.StatusCode.OK) {
                return Ok("Объект specialization успешно отредактирован");
            }

            return BadRequest("Не получилось отредактировать объект specialization");

        }

    }
}