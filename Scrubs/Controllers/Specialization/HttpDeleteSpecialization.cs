using System;

using Microsoft.AspNetCore.Mvc;
using Scrubs.Service.Implementations;
using Scrubs.Service.Interfaces;

namespace Scrubs.API.Controllers {

    [ApiController]
    [Route("api/specialization/[controller]")]
    public class HttpDeleteSpecialization : ControllerBase {

        private readonly ISpecializationService _specializationService;

        public HttpDeleteSpecialization(ISpecializationService specializationService) {
            _specializationService = specializationService;
        }

        [HttpDelete("delete-specialization/{id}")]
        public async Task<IActionResult> DeleteSpecialization(int id) {

            if (id == null) {
                return BadRequest("Запрос должен включать id");
            }

            var response = await _specializationService.DeleteSpecialization(id);

            if (response.StatusCode == Domain.Enum.StatusCode.OK) {
                return Ok("Объект specialization успешно удален");
            }

            return BadRequest("Не получилось удалить объект specialization");

        }

    }
}

