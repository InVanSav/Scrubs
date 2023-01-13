using System;

using Microsoft.AspNetCore.Mvc;
using Scrubs.Service.Interfaces;
using Scrubs.Domain.Entity;
using Microsoft.AspNetCore.Authorization;

namespace Scrubs.API.Controllers {

    [ApiController]
    [Route("api/appointment-doctor/[controller]")]
    public class HttpPostAppointment : ControllerBase {

        private readonly IAppointmentDoctorService _appointmentDoctorService;

        public HttpPostAppointment(IAppointmentDoctorService appointmentDoctorService) {
            _appointmentDoctorService = appointmentDoctorService;
        }

        [HttpPost("create-appointment")]
        [Authorize]
        public async Task<IActionResult> CreateAppointment(AppointmentDoctor appointmentDoctor) {

            if (appointmentDoctor == null) {
                return BadRequest("Запрос должен включать appointment");
            }

            var response = await _appointmentDoctorService.CreateAppointment(appointmentDoctor);

            if (response.StatusCode == Domain.Enum.StatusCode.OK) {
                return Ok("Объект appointment добавился в БД");
            }

            return BadRequest("Не удалось создать объект appointment");

        }

    }
}

