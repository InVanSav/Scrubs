using System;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Scrubs.Domain.Entity;
using Scrubs.Service.Interfaces;

namespace Scrubs.API.Controllers {

    [ApiController]
    [Route("api/appointment-doctor/[controller]")]
    public class HttpDeleteAppointment : ControllerBase {

        private readonly IAppointmentDoctorService _appointmentDoctorService;

        public HttpDeleteAppointment(IAppointmentDoctorService appointmentDoctorService) {
            _appointmentDoctorService = appointmentDoctorService;
        }

        [HttpDelete("delete-appointment/{id}")]
        public async Task<IActionResult> DeleteAppointment(int id) {

            if (id == null) {
                return BadRequest("Запрос должен включать id");
            }

            var response = await _appointmentDoctorService.DeleteAppointment(id);

            if (response.StatusCode == Domain.Enum.StatusCode.OK) {
                return Ok("Объект appointment успешно удален");
            }

            return BadRequest("Не получилось удалить объект appointment");

        }

    }
}

