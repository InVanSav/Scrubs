using System;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Scrubs.Domain.Entity;
using Scrubs.Service.Interfaces;

namespace Scrubs.API.Controllers {

    [ApiController]
    [Route("api/doctor/[controller]")]
    public class HttpPostDoctor : ControllerBase {

        private readonly IDoctorService _doctorService;

        public HttpPostDoctor(IDoctorService doctorService) {
            _doctorService = doctorService;
        }

        [HttpPost("create-doctor/{id}")]
        [Authorize]
        public async Task<IActionResult> CreateAppointment(Doctor doctor) {

            if (doctor == null) {
                return BadRequest("Запрос должен включать doctor");
            }

            var response = await _doctorService.CreateDoctor(doctor);

            if (response.StatusCode == Domain.Enum.StatusCode.OK) {
                return Ok("Объект doctor успешно создан");
            }

            return BadRequest("Не получилось создать объект doctor");

        }

    }
}

