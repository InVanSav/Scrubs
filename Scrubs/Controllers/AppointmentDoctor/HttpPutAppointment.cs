using System;

using Microsoft.AspNetCore.Mvc;
using Scrubs.Service.Interfaces;
using Scrubs.Domain.Entity;

namespace Scrubs.API.Controllers {

    [ApiController]
    [Route("api/appointment-doctor/[controller]")]
    public class HttpPutAppointment : ControllerBase {

        private readonly IAppointmentDoctorService _appointmentDoctorService;

        public HttpPutAppointment(IAppointmentDoctorService appointmentDoctorService) {
            _appointmentDoctorService = appointmentDoctorService;
        }

        [HttpPut("edit-appointment")]
        public async Task<IActionResult> EditAppointment(int id, AppointmentDoctor appointmentDoctor) {

            if (id == null || appointmentDoctor == null) {
                return BadRequest("Запрос должен включать id и appointment");
            }

            var response = await _appointmentDoctorService.Edit(id, appointmentDoctor);

            if (response.StatusCode == Domain.Enum.StatusCode.OK) {
                return Ok("Объект appointment успешно отредактирован");
            }

            return BadRequest("Не удалось отредактировать объект appointment");

        }

    }
}

