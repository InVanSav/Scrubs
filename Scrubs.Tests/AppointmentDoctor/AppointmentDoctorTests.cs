namespace Scrubs.Tests.AppointmentDoctor;

using DAL.Interfaces;
using Domain.Entity;
using Domain.ViewModels.AppointmentDoctor;
using Service.Implementations;

public class AppointmentDoctorTests {

    private readonly AppointmentDoctorService _appointmentDoctorService;
    private readonly Mock<IAppointmentDoctorRepository> _appointmentDoctorRepositoryMock;
    
    public AppointmentDoctorTests() {
        _appointmentDoctorRepositoryMock = new Mock<IAppointmentDoctorRepository>();
        _appointmentDoctorService = new AppointmentDoctorService(_appointmentDoctorRepositoryMock.Object);
    }
    
    [Fact] 
    public void GetAppointmentsOrNo_ShouldWork() {
        
        var appointment = new AppointmentDoctorViewModel {
            IdDoctor = 1,
            IdPatient = 1,
            DateOfStartAppointmentWithDoctor = DateTime.Now,
            DateOfFinishAppointmentWithDoctor = DateTime.Today
        };
        
        _appointmentDoctorRepositoryMock.Setup(repository => repository.Select())
            .Returns(() => appointment);
        
        var res = _appointmentDoctorService.GetAppointments();

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void GetAppointmentByIdPatientOrNo_ShouldFail() {
        
        _appointmentDoctorRepositoryMock.Setup(
            repository => repository.GetByIdOfPatient(It.IsAny<int>()))
            .Returns(() => null);

        var res = _appointmentDoctorService.GetByIdPatient(0);

        Assert.True(res.IsFaulted);
        Assert.Equal("Appointment not found:(", res.Result.Result);
        Assert.Equal(0, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void GetAppointmentByIdDoctorOrNo_ShouldFail() {
        
        _appointmentDoctorRepositoryMock.Setup(
            repository => repository.GetByIdOfDoctor(It.IsAny<int>()))
            .Returns(() => null);

        var res = _appointmentDoctorService.GetByIdDoctor(0);

        Assert.True(res.IsFaulted);
        Assert.Equal("Appointment not found:(", res.Result.Result);
        Assert.Equal(0, (int)res.Result.StatusCode);

    }

    [Fact] public void GetAppointmentByDayOfStartOrNo_ShouldWork() {
        
        _appointmentDoctorRepositoryMock.Setup(
            repository => repository.GetByDateOfStartAppointmentWithDoctor(DateTime.Now))
            .Returns(() => DateTime.Now);

        var res = _appointmentDoctorService.GetByDateOfStartAppointment(DateTime.Now);

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }

    [Fact] 
    public void GetAppointmentByDayOfFinishOrNo_ShouldFail() {
        
        _appointmentDoctorRepositoryMock.Setup(
            repository => repository.GetByDateOfFinishAppointmentWithDoctor(It.IsAny<DateTime>()))
            .Returns(() => null);

        var res = _appointmentDoctorService.GetByDateOfFinishAppointment(DateTime.Today);

        Assert.True(res.IsFaulted);
        Assert.Equal("Appointment not found:(", res.Result.Result);
        Assert.Equal(0, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void DeleteAppointmentOrNo_ShouldWork() {
        
        var appointment = new AppointmentDoctor {
            IdDoctor = 0,
            IdPatient = 1,
            DateOfStartAppointmentWithDoctor = DateTime.Now,
            DateOfFinishAppointmentWithDoctor = DateTime.Today
        };
        
        _appointmentDoctorRepositoryMock.Setup(repository => repository.Delete(appointment))
            .Returns(() => true);

        var res = _appointmentDoctorService.DeleteAppointment(0);

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void CreateAppointmentOrNo_ShouldWork() {

        var appointment = new AppointmentDoctor {
            IdDoctor = 0,
            IdPatient = 0,
            DateOfStartAppointmentWithDoctor = DateTime.Now,
            DateOfFinishAppointmentWithDoctor = DateTime.Today
        };
        
        _appointmentDoctorRepositoryMock.Setup(repository => repository.Create(appointment))
            .Returns(() => true);

        var res = _appointmentDoctorService.CreateAppointment(appointment);

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }

    [Fact] 
    public void EditAppointmentOrNo_ShouldWork() {

        var appointment = new AppointmentDoctor {
            IdDoctor = 0,
            IdPatient = 0,
            DateOfStartAppointmentWithDoctor = DateTime.Now,
            DateOfFinishAppointmentWithDoctor = DateTime.Today,
            FreeTimeOfDoctor = DateTime.Now
        };
        
        _appointmentDoctorRepositoryMock.Setup(repository => repository.Update(appointment))
            .Returns(() => true);

        var res = _appointmentDoctorService.Edit(0, appointment);

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void GetFreeAppointmentOrNo_ShouldFail() {

        _appointmentDoctorRepositoryMock.Setup(repository => repository.Get(It.IsAny<int>()))
            .Returns(() => null);

        var res = _appointmentDoctorService.GetFreeAppointment(0);

        Assert.True(res.IsFaulted);
        Assert.Equal("Appointment not found:(", res.Result.Result);

        Assert.Equal(0, (int)res.Result.StatusCode);

    }

}
