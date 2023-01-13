using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Scrubs.Domain.Entity;
using Scrubs.Service.Interfaces;

namespace Scrubs.API.Controllers {

    [ApiController]
    [Route("api/time-table/[controller]")]
    public class HttpPostTimeTable : ControllerBase {

        private readonly ITimeTableService _timeTableService;

        public HttpPostTimeTable(ITimeTableService timeTableService) {
            _timeTableService = timeTableService;
        }

        [HttpPost("create-time-table")]
        [Authorize]
        public async Task<IActionResult> CreateTimeTable(TimeTable timeTable) {

            if (timeTable == null) {
                return BadRequest("Запрос должен включать timeTable");
            }

            var response = await _timeTableService.CreateTimeTable(timeTable);

            if (response.StatusCode == Domain.Enum.StatusCode.OK) {
                return Ok(response.Data);
            }

            return NoContent();

        }

    }
}