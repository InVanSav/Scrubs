using Microsoft.AspNetCore.Mvc;

namespace Scrubs.Controllers;

using Domain.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Service.Interfaces;

public class UserController : Controller {

    private readonly IUserService _userService;

    public UserController(IUserService userService) {
        _userService = userService;
    }
    
    [HttpGet]
    public async Task<ViewResult> GetUsers() {
        
        var response = await _userService.GetUsers();
        
        if (response.StatusCode == Domain.Enum.StatusCode.OK){
            return View(response.Data);
        }
        return View("Error");
        
    }
    
    [HttpGet]
    public async Task<ViewResult> GetUser(int id) {
        
        var response = await _userService.Get(id);
        
        if (response.StatusCode == Domain.Enum.StatusCode.OK){
            return View(response.Data);
        }
        return View("Error");
        
    }
    
    [HttpGet]
    public async Task<ViewResult> GetByPhoneNumber(int id) {
        
        var response = await _userService.GetByPhoneNumber(id);
        
        if (response.StatusCode == Domain.Enum.StatusCode.OK){
            return View(response.Data);
        }
        return View("Error");
        
    }
    
    [HttpGet]
    public async Task<ViewResult> GetByRole(string role) {
        
        var response = await _userService.GetByRole(role);
        
        if (response.StatusCode == Domain.Enum.StatusCode.OK){
            return View(response.Data);
        }
        return View("Error");
        
    }
    
    [HttpGet]
    public async Task<ViewResult> GetByPassword(string password) {
        
        var response = await _userService.GetByPassword(password);
        
        if (response.StatusCode == Domain.Enum.StatusCode.OK){
            return View(response.Data);
        }
        return View("Error");
        
    }
    
    [HttpGet]
    public async Task<ViewResult> GetByLoginAndPassword(string fullName, string password) {

        var response = await _userService.GetByLoginAndPassword(fullName, password);
        
        if (response.StatusCode == Domain.Enum.StatusCode.OK){
            return View(response.Data);
        }
        return View("Error");
        
    }
    
    [HttpGet]
    public async Task<ViewResult> GetByName(string fullName) {

        var response = await _userService.GetByName(fullName);
        
        if (response.StatusCode == Domain.Enum.StatusCode.OK){
            return View(response.Data);
        }
        return View("Error");
        
    }
    
    [HttpGet]
    public async Task<ViewResult> CreateUser(UserViewModel user) {

        var response = await _userService.CreateUser(user);
        
        if (response.StatusCode == Domain.Enum.StatusCode.OK) {
            return View(response.Data);
        }
        return View("Error");
        
    }
    
    [Authorize(Roles = "Admin")]
    public async Task<ViewResult> DeleteUser(int id) {

        var response = await _userService.DeleteUser(id);
        
        if (response.StatusCode == Domain.Enum.StatusCode.OK) {
            return View("GetUsers");
        }
        return View("Error");
        
    }
    
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<ViewResult> Save(int id) {

        if (id == 0) {
            return View("Error");
        }

        var response = await _userService.Get(id);
        
        if (response.StatusCode == Domain.Enum.StatusCode.OK) {
            return View(response.Data);
        }
        return View("Error");
        
    }
    
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ViewResult> Save(UserViewModel userViewModel) {

        if (ModelState.IsValid) {
            if (userViewModel.Id == 0) {
                await _userService.CreateUser(userViewModel);
            } else{
                await _userService.Edit(userViewModel.Id, userViewModel);
            }
        }

        return View("GetUsers");
        
    }
    
}
