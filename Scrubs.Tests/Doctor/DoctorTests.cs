namespace Scrubs.Tests.Doctor;

using DAL.Interfaces;
using Domain.ViewModels.Doctor;
using Service.Implementations;

public class DoctorTests {

    private readonly DoctorService _doctorService;

    public DoctorTests() {
        var doctorRepositoryMock = new Mock<IDoctorRepository>();
        _doctorService = new DoctorService(doctorRepositoryMock.Object);
    }
    
    [Fact] 
    public void GetDoctorOrNo_ShouldWork() {

        var res = _doctorService.Get(0);

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void GetDoctorsOrNo_ShouldWork() {

        var res = _doctorService.GetDoctors();

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }

    [Fact] 
    public void GetDoctorByFullNameOrNo_ShouldFail() {

        var res = _doctorService.GetByFullName("Stephan");

        Assert.True(res.IsFaulted);
        Assert.Equal("Doctor not found:(", res.Result.Result);
        Assert.Equal(0, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void GetDoctorByJobTitleOrNo_ShouldWork() {

        var res = _doctorService.GetByJobTitle("Pediatrician");

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }

    [Fact] 
    public void DeleteDoctorOrNo_ShouldWork() {

        var res = _doctorService.DeleteDoctor(0);

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void CreateDoctorOrNo_ShouldWork() {

        var doctor = new DoctorViewModel {
            Id = 0,
            FullName = "Stephan",
            JobTitle = "Pediatrician"
        };

        var res = _doctorService.CreateDoctor(doctor);

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void EditDoctorOrNo_ShouldWork() {

        var doctor = new DoctorViewModel {
            Id = 0,
            FullName = "Stephan",
            JobTitle = "Pediatrician"
        };

        var res = _doctorService.Edit(0, doctor);

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }
    
}
