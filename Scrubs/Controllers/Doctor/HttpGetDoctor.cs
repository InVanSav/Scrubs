using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Scrubs.Service.Interfaces;

namespace Scrubs.API.Controllers {

    [ApiController]
    [Route("api/appointment-doctor/[controller]")]
    public class HttpGetDoctor : ControllerBase {

        private readonly IDoctorService _doctorService;

        public HttpGetDoctor(IDoctorService doctorService) {
            _doctorService = doctorService;
        }

        [HttpGet("get-doctors")]
        public async Task<IActionResult> GetDoctors() {

            var response = await _doctorService.GetDoctors();

            if (response.Result == "Doctors not found:(") {
                return BadRequest("Ничего не найдено");
            }

            if (response.StatusCode == Domain.Enum.StatusCode.OK) {
                return Ok(response.Data);
            };

            return NoContent();

        }

        [HttpGet("get-doctor-by-id/{id}")]
        public async Task<IActionResult> GetDoctor(int id) {

            var response = await _doctorService.Get(id);

            if (response.Result == "Doctor not found:(") {
                return BadRequest("Ничего не найдено");
            }

            if (response.StatusCode == Domain.Enum.StatusCode.OK) {
                return Ok(response.Data);
            }

            return NoContent();

        }

        [HttpGet("get-doctor-by-fullname/{fullname}")]
        public async Task<IActionResult> GetByFullName(string fullname) {

            var response = await _doctorService.GetByFullName(fullname);

            if (response.Result == "Doctor not found:(") {
                return BadRequest("Ничего не найдено");
            }

            if (response.StatusCode == Domain.Enum.StatusCode.OK) {
                return Ok(response.Data);
            }

            return NoContent();

        }

        [HttpGet("get-doctor-by-job-title/{job-title}")]
        public async Task<IActionResult> GetByJobTitle(string jobTitle) {

            var response = await _doctorService.GetByJobTitle(jobTitle);

            if (response.Result == "Doctor not found:(") {
                return BadRequest("Ничего не найдено");
            }

            if (response.StatusCode == Domain.Enum.StatusCode.OK) {
                return Ok(response.Data);
            }

            return NoContent();

        }

    }

}

