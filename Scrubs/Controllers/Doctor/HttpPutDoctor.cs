using System;

using Microsoft.AspNetCore.Mvc;
using Scrubs.Service.Interfaces;
using Scrubs.Domain.Entity;

namespace Scrubs.API.Controllers {

    [ApiController]
    [Route("api/doctor/[controller]")]
    public class HttpPutDoctor : ControllerBase {

        private readonly IDoctorService _doctorService;

        public HttpPutDoctor(IDoctorService doctorService) {
            _doctorService = doctorService;
        }

        [HttpPut("edit-doctor")]
        public async Task<IActionResult> EditDoctor(int id, Doctor doctor) {

            if (id == null || doctor == null) {
                return BadRequest("Запрос должен включать id и doctor");
            }

            var response = await _doctorService.Edit(id, doctor);

            if (response.StatusCode == Domain.Enum.StatusCode.OK) {
                return Ok("Объект appointment успешно отредактирован");
            }

            return BadRequest("Не удалось отредактировать объект appointment");

        }

    }
}

