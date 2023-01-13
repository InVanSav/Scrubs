using System;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Scrubs.Domain.Entity;
using Scrubs.Service.Interfaces;

namespace Scrubs.API.Controllers {

    [ApiController]
    [Route("api/appointment-doctor/[controller]")]
    public class HttpGetAppointment : ControllerBase {

        private readonly IAppointmentDoctorService _appointmentDoctorService;

        public HttpGetAppointment(IAppointmentDoctorService appointmentDoctorService) {

            _appointmentDoctorService = appointmentDoctorService;

        }

        [HttpGet("get-appointments")]
        public async Task<IActionResult> GetAppointmentsDoctor() {

            var response = await _appointmentDoctorService.GetAppointments();

            if (response.Result == "Appointments not found:(") {
                return BadRequest("Ничего не найдено");
            }

            if (response.StatusCode == Domain.Enum.StatusCode.OK) {
                return Ok(response.Data);
            };

            return NoContent();

        }

        [HttpGet("get-appointment-by-id-patient/{id}")]
        public async Task<IActionResult> GetByIdPatient(int idPatient) {

            var response = await _appointmentDoctorService.GetByIdPatient(idPatient);

            if (response.Result == "Appointment not found:(") {
                return BadRequest("Ничего не найдено");
            }

            if (response.StatusCode == Domain.Enum.StatusCode.OK) {
                return Ok(response.Data);
            }

            return NoContent();

        }

        [HttpGet("get-appointment-by-id-doctor/{id}")]
        public async Task<IActionResult> GetByIdDoctor(int idDoctor) {

            var response = await _appointmentDoctorService.GetByIdDoctor(idDoctor);

            if (response.Result == "Appointment not found:(") {
                return BadRequest("Ничего не найдено");
            }

            if (response.StatusCode == Domain.Enum.StatusCode.OK) {
                return Ok(response.Data);
            }

            return NoContent();

        }

        [HttpGet("get-appointment-by-date-start/{date}")]
        public async Task<IActionResult> GetByDateOfStartAppointment(DateTime start) {

            var response = await _appointmentDoctorService.GetByDateOfStartAppointment(start);

            if (response.Result == "Appointment not found:(") {
                return BadRequest("Ничего не найдено");
            }

            if (response.StatusCode == Domain.Enum.StatusCode.OK) {
                return Ok(response.Data);
            }

            return NoContent();

        }

        [HttpGet("get-appointment-by-date-finish/{date}")]
        public async Task<IActionResult> GetByDateOfFinishAppointment(DateTime finish) {

            var response = await _appointmentDoctorService.GetByDateOfFinishAppointment(finish);

            if (response.Result == "Appointment not found:(") {
                return BadRequest("Ничего не найдено");
            }

            if (response.StatusCode == Domain.Enum.StatusCode.OK) {
                return Ok(response.Data);
            }

            return NoContent();

        }

    }

}

