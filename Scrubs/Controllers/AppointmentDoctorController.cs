using Microsoft.AspNetCore.Mvc;

namespace Scrubs.Controllers;

using Domain.ViewModels.AppointmentDoctor;
using Microsoft.AspNetCore.Authorization;
using Service.Interfaces;

public class AppointmentDoctorController : Controller {

    private readonly IAppointmentDoctorService _appointmentDoctorService;

    public AppointmentDoctorController(IAppointmentDoctorService appointmentDoctorService) {
        _appointmentDoctorService = appointmentDoctorService;
    }
    
    [HttpGet]
    public async Task<ViewResult> GetAppointmentsDoctor() {
        
        var response = await _appointmentDoctorService.GetAppointments();
        
        if (response.StatusCode == Domain.Enum.StatusCode.OK){
            return View(response.Data);
        }
        return View("Error");
        
    }

    [HttpGet]
    public async Task<ViewResult> GetByIdPatient(int idPatient) {
        
        var response = await _appointmentDoctorService.GetByIdPatient(idPatient);
        
        if (response.StatusCode == Domain.Enum.StatusCode.OK){
            return View(response.Data);
        }
        return View("Error");
        
    }
    
    [HttpGet]
    public async Task<ViewResult> GetByIdDoctor(int idDoctor) {
        
        var response = await _appointmentDoctorService.GetByIdDoctor(idDoctor);
        
        if (response.StatusCode == Domain.Enum.StatusCode.OK){
            return View(response.Data);
        }
        return View("Error");
        
    }
    
    [HttpGet]
    public async Task<ViewResult> GetByDateOfStartAppointment(DateTime start) {
        
        var response = await _appointmentDoctorService.GetByDateOfStartAppointment(start);
        
        if (response.StatusCode == Domain.Enum.StatusCode.OK){
            return View(response.Data);
        }
        return View("Error");
        
    }
    
    [HttpGet]
    public async Task<ViewResult> GetByDateOfFinishAppointment(DateTime finish) {
        
        var response = await _appointmentDoctorService.GetByDateOfFinishAppointment(finish);
        
        if (response.StatusCode == Domain.Enum.StatusCode.OK){
            return View(response.Data);
        }
        return View("Error");
        
    }
    
    [HttpGet]
    public async Task<ViewResult> CreateAppointment(AppointmentDoctorViewModel appointmentDoctorView) {

        var response = await _appointmentDoctorService.CreateAppointment(appointmentDoctorView);
        
        if (response.StatusCode == Domain.Enum.StatusCode.OK) {
            return View(response.Data);
        }
        return View("Error");
        
    }
    
    [Authorize(Roles = "Admin")]
    public async Task<RedirectToActionResult> DeleteAppointment(int id) {

        var response = await _appointmentDoctorService.DeleteAppointment(id);
        
        if (response.StatusCode == Domain.Enum.StatusCode.OK) {
            return RedirectToAction("GetAppointmentsDoctor");
        }
        return RedirectToAction("Error");
        
    }
    
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<ViewResult> Save(int id) {

        if (id == 0) {
            return View("Error");
        }

        var response = await _appointmentDoctorService.GetByIdDoctor(id);
        
        if (response.StatusCode == Domain.Enum.StatusCode.OK) {
            return View(response.Data);
        }
        return View("Error");
        
    }
    
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ViewResult> Save(AppointmentDoctorViewModel appointmentDoctorViewModel) {

        if (ModelState.IsValid) {
            if (appointmentDoctorViewModel.IdDoctor == 0) {
                await _appointmentDoctorService.CreateAppointment(appointmentDoctorViewModel);
            } else{
                await _appointmentDoctorService.Edit(appointmentDoctorViewModel.IdDoctor, appointmentDoctorViewModel);
            }
        }

        return View("GetAppointmentsDoctor");
        
    }

    public IActionResult Error() {
        throw new NotImplementedException();
    }
    
}
