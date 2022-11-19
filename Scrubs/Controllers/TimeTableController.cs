using Microsoft.AspNetCore.Mvc;

namespace Scrubs.Controllers;

using Domain.ViewModels.TimeTable;
using Microsoft.AspNetCore.Authorization;
using Service.Interfaces;

public class TimeTableController : Controller {
    
    private readonly ITimeTableService _timeTableService;

    public TimeTableController(ITimeTableService timeTableService) {
        _timeTableService = timeTableService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetTimeTables() {
        
        var response = await _timeTableService.GetTimeTables();
        
        if (response.StatusCode == Domain.Enum.StatusCode.OK){
            return View(response.Data);
        }
        return View("Error");
        
    }
    
    [HttpGet]
    public async Task<IActionResult> GetTimeTable(int id) {
        
        var response = await _timeTableService.GetTimeTable(id);
        
        if (response.StatusCode == Domain.Enum.StatusCode.OK){
            return View(response.Data);
        }
        return View("Error");
        
    }
    
    [HttpGet]
    public async Task<IActionResult> GetByStartOfWorkDayDoctor(DateTime start) {
        
        var response = await _timeTableService.GetByStartOfWorkDayDoctor(start);
        
        if (response.StatusCode == Domain.Enum.StatusCode.OK){
            return View(response.Data);
        }
        return View("Error");
        
    }
    
    [HttpGet]
    public async Task<IActionResult> GetByFinishOfWorkDayDoctor(DateTime finish) {
        
        var response = await _timeTableService.GetByFinishOfWorkDayDoctor(finish);
        
        if (response.StatusCode == Domain.Enum.StatusCode.OK){
            return View(response.Data);
        }
        return View("Error");
        
    }
    
    [HttpGet]
    public async Task<ViewResult> CreateTimeTable(TimeTableViewModel timeTableViewModel) {

        var response = await _timeTableService.CreateTimeTable(timeTableViewModel);
        
        if (response.StatusCode == Domain.Enum.StatusCode.OK) {
            return View(response.Data);
        }
        return View("Error");
        
    }
    
    [Authorize(Roles = "Admin")]
    public async Task<ViewResult> DeleteTimeTable(int id) {

        var response = await _timeTableService.DeleteTimeTable(id);
        
        if (response.StatusCode == Domain.Enum.StatusCode.OK) {
            return View("GetTimeTables");
        }
        return View("Error");
        
    }
    
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<ViewResult> Save(int id) {

        if (id == 0) {
            return View("Error");
        }

        var response = await _timeTableService.GetTimeTable(id);
        
        if (response.StatusCode == Domain.Enum.StatusCode.OK) {
            return View(response.Data);
        }
        return View("Error");
        
    }
    
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ViewResult> Save(TimeTableViewModel timeTableViewModel) {

        if (ModelState.IsValid) {
            if (timeTableViewModel.IdOfDoctor == 0) {
                await _timeTableService.CreateTimeTable(timeTableViewModel);
            } else{
                await _timeTableService.Edit(timeTableViewModel.IdOfDoctor, timeTableViewModel);
            }
        }

        return View("GetTimeTables");
        
    }
    
}
