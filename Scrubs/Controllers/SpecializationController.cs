using Microsoft.AspNetCore.Mvc;

namespace Scrubs.Controllers;

using Domain.ViewModels.Specialization;
using Domain.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Service.Interfaces;

public class SpecializationController : Controller {

    private readonly ISpecializationService _specializationService;

    public SpecializationController(ISpecializationService specializationService) {
        _specializationService = specializationService;
    }

    [HttpGet]
    public async Task<IActionResult> GetSpecializations() {
        
        var response = await _specializationService.GetSpecializations();
        
        if (response.StatusCode == Domain.Enum.StatusCode.OK){
            return View(response.Data);
        }
        return View("Error");
        
    }
    
    [HttpGet]
    public async Task<IActionResult> GetByName(string name) {
        
        var response = await _specializationService.GetByName(name);
        
        if (response.StatusCode == Domain.Enum.StatusCode.OK){
            return View(response.Data);
        }
        return View("Error");
        
    }
    
    [HttpGet]
    public async Task<IActionResult> GetSpecialization(int id) {
        
        var response = await _specializationService.Get(id);
        
        if (response.StatusCode == Domain.Enum.StatusCode.OK){
            return View(response.Data);
        }
        return View("Error");
        
    }
    
    [HttpGet]
    public async Task<ViewResult> CreateSpecialization(SpecializationViewModel specializationViewModel) {

        var response = await _specializationService.CreateSpecialization(specializationViewModel);
        
        if (response.StatusCode == Domain.Enum.StatusCode.OK) {
            return View(response.Data);
        }
        return View("Error");
        
    }
    
    [Authorize(Roles = "Admin")]
    public async Task<ViewResult> DeleteSpecialization(int id) {

        var response = await _specializationService.DeleteSpecialization(id);
        
        if (response.StatusCode == Domain.Enum.StatusCode.OK) {
            return View("GetSpecializations");
        }
        return View("Error");
        
    }
    
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<ViewResult> Save(int id) {

        if (id == 0) {
            return View("Error");
        }

        var response = await _specializationService.Get(id);
        
        if (response.StatusCode == Domain.Enum.StatusCode.OK) {
            return View(response.Data);
        }
        return View("Error");
        
    }
    
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ViewResult> Save(SpecializationViewModel specializationViewModel) {

        if (ModelState.IsValid) {
            if (specializationViewModel.Id == 0) {
                await _specializationService.CreateSpecialization(specializationViewModel);
            } else{
                await _specializationService.Edit(specializationViewModel.Id, specializationViewModel);
            }
        }

        return View("GetSpecializations");
        
    }
    
}
