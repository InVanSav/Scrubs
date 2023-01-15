using System;

using Microsoft.AspNetCore.Mvc;
using Scrubs.Service.Implementations;
using Scrubs.Service.Interfaces;

namespace Scrubs.API.Controllers {

    [ApiController]
    [Route("api/time-table/[controller]")]
    public class HttpDeleteTimeTable : ControllerBase {

        private readonly ITimeTableService _timeTableService;

        public HttpDeleteTimeTable(ITimeTableService timeTableService) {
            _timeTableService = timeTableService;
        }

        [HttpDelete("delete-time-table/{id}")]
        public async Task<IActionResult> DeleteTimeTable(int id) {

            if (id == null) {
                return BadRequest("Запрос должен включать id");
            }

            var response = await _timeTableService.DeleteTimeTable(id);

            if (response.StatusCode == Domain.Enum.StatusCode.OK) {
                return Ok("Объект timeTable успешно удален");
            }

            return BadRequest("Не получилось удалить объект timeTable");

        }

    }
}

