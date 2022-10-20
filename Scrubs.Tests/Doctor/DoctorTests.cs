namespace Scrubs.Tests.Doctor;

using Domain.ViewModels.Doctor;
using Service.Implementations;

public class DoctorTests {

    private readonly DoctorService _doctorService;

    public DoctorTests(DoctorService doctorService) {
        _doctorService = doctorService;
    }
    
    [Fact] 
    public void GetDoctorOrNo_ShouldFail() {

        var res = _doctorService.Get(0);

        Assert.True(res.IsFaulted);
        Assert.Equal("Doctor not found:(", res.Result.Result);
        Assert.Equal(2, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void GetDoctorsOrNo_ShouldFail() {

        var res = _doctorService.GetDoctors();

        Assert.True(res.IsFaulted);
        Assert.Equal("Doctors not found:(", res.Result.Result);
        Assert.Equal(2, (int)res.Result.StatusCode);

    }

    [Fact] 
    public void GetDoctorByFullNameOrNo_ShouldFail() {

        var res = _doctorService.GetByFullName("Stephan");

        Assert.True(res.IsFaulted);
        Assert.Equal("Doctor not found:(", res.Result.Result);
        Assert.Equal(2, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void GetDoctorByJobTitleOrNo_ShouldFail() {

        var res = _doctorService.GetByJobTitle("Pediatrician");

        Assert.True(res.IsFaulted);
        Assert.Equal("Doctor not found:(", res.Result.Result);
        Assert.Equal(2, (int)res.Result.StatusCode);

    }

    [Fact] 
    public void DeleteDoctorOrNo_ShouldFail() {

        var res = _doctorService.DeleteDoctor(0);

        Assert.True(res.IsFaulted);
        Assert.Equal("Doctor not found:(", res.Result.Result);
        Assert.Equal(2, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void CreateDoctorOrNo_ShouldFail() {

        var doctor = new DoctorViewModel {
            Id = 0,
            FullName = "Stephan",
            JobTitle = "Pediatrician"
        };

        var res = _doctorService.CreateDoctor(doctor);

        Assert.True(res.IsFaulted);
        Assert.Equal("Doctor wasn't create:(", res.Result.Result);
        Assert.Equal(3, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void EditDoctorOrNo_ShouldFail() {

        var doctor = new DoctorViewModel {
            Id = 0,
            FullName = "Stephan",
            JobTitle = "Pediatrician"
        };

        var res = _doctorService.Edit(0, doctor);

        Assert.True(res.IsFaulted);
        Assert.Equal("Doctor not found:(", res.Result.Result);
        Assert.Equal(2, (int)res.Result.StatusCode);

    }
    
}
