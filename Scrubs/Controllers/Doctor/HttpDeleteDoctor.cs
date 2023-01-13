using System;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Scrubs.Service.Interfaces;

namespace Scrubs.API.Controllers {

    [ApiController]
    [Route("api/doctor/[controller]")]
    public class HttpDeleteDoctor : ControllerBase {

        private readonly IDoctorService _doctorService;

        public HttpDeleteDoctor(IDoctorService doctorService) {
            _doctorService = doctorService;
        }

        [HttpDelete("delete-doctor/{id}")]
        public async Task<IActionResult> DeleteAppointment(int id) {

            if (id == null) {
                return BadRequest("Запрос должен включать id");
            }

            var response = await _doctorService.DeleteDoctor(id);

            if (response.StatusCode == Domain.Enum.StatusCode.OK) {
                return Ok("Объект doctor успешно удален");
            }

            return BadRequest("Не получилось удалить объект doctor");

        }

    }
}

