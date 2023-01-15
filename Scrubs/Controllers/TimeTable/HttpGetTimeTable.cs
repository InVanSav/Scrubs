using System;

using Microsoft.AspNetCore.Mvc;
using Scrubs.Service.Interfaces;

namespace Scrubs.API.Controllers {

    [ApiController]
    [Route("api/time-table/[controller]")]
    public class HttpGetTimeTable : ControllerBase {

        private readonly ITimeTableService _timeTableService;

        public HttpGetTimeTable(ITimeTableService timeTableService) {
            _timeTableService = timeTableService;
        }

        [HttpGet("get-time-tables")]
        public async Task<IActionResult> GetTimeTables() {

            var response = await _timeTableService.GetTimeTables();

            if (response.Result == "TimeTables not found:(") {
                return BadRequest("Ничего не найдено");
            }

            if (response.StatusCode == Domain.Enum.StatusCode.OK) {
                return Ok(response.Data);
            }

            return NoContent();

        }

        [HttpGet("get-time-table/{id}")]
        public async Task<IActionResult> GetTimeTable(int id) {

            var response = await _timeTableService.GetTimeTable(id);

            if (response.Result == "TimeTable not found:(") {
                return BadRequest("Ничего не найдено");
            }

            if (response.StatusCode == Domain.Enum.StatusCode.OK) {
                return Ok(response.Data);
            }

            return NoContent();

        }

        [HttpGet("get-time-table-by-start/{date-start}")]
        public async Task<IActionResult> GetByStartOfWorkDayDoctor(DateTime start) {

            var response = await _timeTableService.GetByStartOfWorkDayDoctor(start);

            if (response.Result == "TimeTable not found:(") {
                return BadRequest("Ничего не найдено");
            }

            if (response.StatusCode == Domain.Enum.StatusCode.OK) {
                return Ok(response.Data);
            }

            return NoContent();

        }

        [HttpGet("get-time-table-by-finish/{date-finish}")]
        public async Task<IActionResult> GetByFinishOfWorkDayDoctor(DateTime finish) {

            var response = await _timeTableService.GetByFinishOfWorkDayDoctor(finish);

            if (response.Result == "TimeTable not found:(") {
                return BadRequest("Ничего не найдено");
            }

            if (response.StatusCode == Domain.Enum.StatusCode.OK) {
                return Ok(response.Data);
            }

            return NoContent();

        }

    }

}

