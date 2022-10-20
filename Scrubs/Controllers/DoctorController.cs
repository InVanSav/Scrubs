using Microsoft.AspNetCore.Mvc;

namespace Scrubs.Controllers;

using Domain.ViewModels.Doctor;
using Microsoft.AspNetCore.Authorization;
using Service.Interfaces;

public class DoctorController : Controller {
    
    private readonly IDoctorService _doctorService;

    public DoctorController(IDoctorService doctorService) {
        _doctorService = doctorService;
    }

    [HttpGet]
    public async Task<ViewResult> GetDoctors() {
        
        var response = await _doctorService.GetDoctors();
        
        if (response.StatusCode == Domain.Enum.StatusCode.OK){
            return View(response.Data);
        }
        return View("Error");
        
    }
    
    [HttpGet]
    public async Task<ViewResult> GetDoctor(int id) {
        
        var response = await _doctorService.Get(id);
        
        if (response.StatusCode == Domain.Enum.StatusCode.OK){
            return View(response.Data);
        }
        return View("Error");
        
    }
    
    [HttpGet]
    public async Task<ViewResult> GetByFullName(string fullName) {
        
        var response = await _doctorService.GetByFullName(fullName);
        
        if (response.StatusCode == Domain.Enum.StatusCode.OK){
            return View(response.Data);
        }
        return View("Error");
        
    }
    
    [HttpGet]
    public async Task<ViewResult> GetByJobTitle(string jobTitle) {
        
        var response = await _doctorService.GetByJobTitle(jobTitle);
        
        if (response.StatusCode == Domain.Enum.StatusCode.OK){
            return View(response.Data);
        }
        return View("Error");
        
    }
    
    [HttpGet]
    public async Task<ViewResult> CreateDoctor(DoctorViewModel doctorViewModel) {

        var response = await _doctorService.CreateDoctor(doctorViewModel);
        
        if (response.StatusCode == Domain.Enum.StatusCode.OK) {
            return View(response.Data);
        }
        return View("Error");
        
    }
    
    [Authorize(Roles = "Admin")]
    public async Task<ViewResult> DeleteUser(int id) {

        var response = await _doctorService.DeleteDoctor(id);
        
        if (response.StatusCode == Domain.Enum.StatusCode.OK) {
            return View("GetDoctors");
        }
        return View("Error");
        
    }
    
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<ViewResult> Save(int id) {

        if (id == 0) {
            return View("Error");
        }

        var response = await _doctorService.Get(id);
        
        if (response.StatusCode == Domain.Enum.StatusCode.OK) {
            return View(response.Data);
        }
        return View("Error");
        
    }
    
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ViewResult> Save(DoctorViewModel doctorViewModel) {

        if (ModelState.IsValid) {
            if (doctorViewModel.Id == 0) {
                await _doctorService.CreateDoctor(doctorViewModel);
            } else{
                await _doctorService.Edit(doctorViewModel.Id, doctorViewModel);
            }
        }

        return View("GetDoctors");
        
    }
    
}
