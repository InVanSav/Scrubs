using System;

using Microsoft.AspNetCore.Mvc;
using Scrubs.Service.Interfaces;

namespace Scrubs.API.Controllers {

    [ApiController]
    [Route("api/specialization/[controller]")]
    public class HttpGetSpecialization : ControllerBase {

        private readonly ISpecializationService _specializationService;

        public HttpGetSpecialization(ISpecializationService specializationService) {
            _specializationService = specializationService;
        }

        [HttpGet("get-specializations")]
        public async Task<IActionResult> GetSpecializations() {

            var response = await _specializationService.GetSpecializations();

            if (response.Result == "Specializations not found:(") {
                return BadRequest("Ничего не найдено");
            }

            if (response.StatusCode == Domain.Enum.StatusCode.OK) {
                return Ok(response.Data);
            }

            return NoContent();

        }

        [HttpGet("get-specialization-by-name/{name}")]
        public async Task<IActionResult> GetByName(string name) {

            var response = await _specializationService.GetByName(name);

            if (response.Result == "Specialization not found:(") {
                return BadRequest("Ничего не найдено");
            }

            if (response.StatusCode == Domain.Enum.StatusCode.OK) {
                return Ok(response.Data);
            }

            return NoContent();

        }

        [HttpGet("get-specialization-by-id/{id}")]
        public async Task<IActionResult> GetSpecialization(int id) {

            var response = await _specializationService.Get(id);

            if (response.Result == "Specialization not found:(") {
                return BadRequest("Ничего не найдено");
            }

            if (response.StatusCode == Domain.Enum.StatusCode.OK) {
                return Ok(response.Data);
            }

            return NoContent();

        }

    }
}

