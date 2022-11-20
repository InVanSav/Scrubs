namespace Scrubs.Tests.Doctor;

using DAL.Interfaces;
using Domain.Entity;
using Domain.ViewModels.Doctor;
using Service.Implementations;

public class DoctorTests {

    private readonly DoctorService _doctorService;
    private readonly Mock<IDoctorRepository> _doctorRepositoryMock;

    public DoctorTests() {
        _doctorRepositoryMock = new Mock<IDoctorRepository>();
        _doctorService = new DoctorService(_doctorRepositoryMock.Object);
    }
    
    [Fact] 
    public void GetDoctorOrNo_ShouldWork() {
        
        var doctor = new DoctorViewModel {
            Id = 0,
            FullName = "Stephan",
            JobTitle = "Pediatrician"
        };
        
        _doctorRepositoryMock.Setup(repository => repository.Get(0))
            .Returns(() => doctor);

        var res = _doctorService.Get(0);

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void GetDoctorsOrNo_ShouldWork() {
        
        var doctor = new DoctorViewModel {
            Id = 0,
            FullName = "Stephan",
            JobTitle = "Pediatrician"
        };
        
        _doctorRepositoryMock.Setup(repository => repository.Select())
            .Returns(() => doctor);

        var res = _doctorService.GetDoctors();

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }

    [Fact] 
    public void GetDoctorByFullNameOrNo_ShouldFail() {
        
        _doctorRepositoryMock.Setup(
            repository => repository.GetDoctorByFullName(It.IsAny<string>()))
            .Returns(() => null);

        var res = _doctorService.GetByFullName("Stephan");

        Assert.True(res.IsFaulted);
        Assert.Equal("Doctor not found:(", res.Result.Result);
        Assert.Equal(0, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void GetDoctorByJobTitleOrNo_ShouldWork() {
        
        var doctor = new DoctorViewModel {
            Id = 0,
            FullName = "Stephan",
            JobTitle = "Pediatrician"
        };
        
        _doctorRepositoryMock.Setup(repository => repository.GetDoctorByJobTitle("Pediatrician"))
            .Returns(() => doctor);

        var res = _doctorService.GetByJobTitle("Pediatrician");

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }

    [Fact] 
    public void DeleteDoctorOrNo_ShouldWork() {
        
        var doctor = new Doctor {
            Id = 0,
            FullName = "Stephan",
            JobTitle = "Pediatrician"
        };
        
        _doctorRepositoryMock.Setup(repository => repository.Delete(doctor))
            .Returns(() => true);

        var res = _doctorService.DeleteDoctor(0);

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void CreateDoctorOrNo_ShouldWork() {

        var doctor = new Doctor {
            Id = 0,
            FullName = "Stephan",
            JobTitle = "Pediatrician"
        };
        
        _doctorRepositoryMock.Setup(repository => repository.Create(doctor))
            .Returns(() => true);

        var res = _doctorService.CreateDoctor(doctor);

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void EditDoctorOrNo_ShouldWork() {

        var doctor = new Doctor {
            Id = 0,
            FullName = "Stephan",
            JobTitle = "Pediatrician"
        };
        
        _doctorRepositoryMock.Setup(repository => repository.Update(doctor))
            .Returns(() => true);

        var res = _doctorService.Edit(0, doctor);

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }
    
}
