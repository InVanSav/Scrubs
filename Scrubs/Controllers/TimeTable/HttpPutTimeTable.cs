using System;

using Microsoft.AspNetCore.Mvc;
using Scrubs.Domain.Entity;
using Scrubs.Service.Implementations;
using Scrubs.Service.Interfaces;

namespace Scrubs.API.Controllers {

    [ApiController]
    [Route("api/time-table/[controller]")]
    public class HttpPutTimeTable : ControllerBase {

        private readonly ITimeTableService _timeTableService;

        public HttpPutTimeTable(ITimeTableService timeTableService) {
            _timeTableService = timeTableService;
        }

        [HttpPut("edit-time-table/{id}")]
        public async Task<IActionResult> EditTimeTable(int id, TimeTable timeTable) {

            if (id == null || timeTable == null) {
                return BadRequest("Запрос должен включать timeTable");
            }

            var response = await _timeTableService.Edit(id, timeTable);

            if (response.StatusCode == Domain.Enum.StatusCode.OK) {
                return Ok("Объект timeTable успешно отредактирован");
            }

            return BadRequest("Не получилось отредактировать объект timeTable");

        }

    }
}
