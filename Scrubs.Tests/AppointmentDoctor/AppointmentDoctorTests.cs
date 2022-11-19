namespace Scrubs.Tests.AppointmentDoctor;

using DAL.Interfaces;
using Domain.ViewModels.AppointmentDoctor;
using Service.Implementations;

public class AppointmentDoctorTests {

    private readonly AppointmentDoctorService _appointmentDoctorService;

    public AppointmentDoctorTests() {
        var appointmentDoctorRepositoryMock = new Mock<IAppointmentDoctorRepository>();
        _appointmentDoctorService = new AppointmentDoctorService(appointmentDoctorRepositoryMock.Object);
    }
    
    [Fact] 
    public void GetAppointmentsOrNo_ShouldWork() {

        var res = _appointmentDoctorService.GetAppointments();

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void GetAppointmentByIdPatientOrNo_ShouldFail() {

        var res = _appointmentDoctorService.GetByIdPatient(0);

        Assert.True(res.IsFaulted);
        Assert.Equal("Appointment not found:(", res.Result.Result);
        Assert.Equal(0, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void GetAppointmentByIdDoctorOrNo_ShouldFail() {

        var res = _appointmentDoctorService.GetByIdDoctor(0);

        Assert.True(res.IsFaulted);
        Assert.Equal("Appointment not found:(", res.Result.Result);
        Assert.Equal(0, (int)res.Result.StatusCode);

    }

    [Fact] public void GetAppointmentByDayOfStartOrNo_ShouldWork() {

        var res = _appointmentDoctorService.GetByDateOfStartAppointment(DateTime.Now);

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }

    [Fact] 
    public void GetAppointmentByDayOfFinishOrNo_ShouldFail() {

        var res = _appointmentDoctorService.GetByDateOfFinishAppointment(DateTime.Today);

        Assert.True(res.IsFaulted);
        Assert.Equal("Appointment not found:(", res.Result.Result);
        Assert.Equal(0, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void DeleteAppointmentOrNo_ShouldWork() {

        var res = _appointmentDoctorService.DeleteAppointment(0);

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void CreateAppointmentOrNo_ShouldWork() {

        var appointment = new AppointmentDoctorViewModel {
            IdDoctor = 0,
            IdPatient = 0,
            DateOfStartAppointmentWithDoctor = DateTime.Now,
            DateOfFinishAppointmentWithDoctor = DateTime.Today
        };

        var res = _appointmentDoctorService.CreateAppointment(appointment);

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }

    [Fact] 
    public void EditAppointmentOrNo_ShouldWork() {

        var appointment = new AppointmentDoctorViewModel {
            IdDoctor = 0,
            IdPatient = 0,
            DateOfStartAppointmentWithDoctor = DateTime.Now,
            DateOfFinishAppointmentWithDoctor = DateTime.Today,
            FreeTimeOfDoctor = DateTime.Now
        };

        var res = _appointmentDoctorService.Edit(0, appointment);

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void GetFreeAppointmentOrNo_ShouldWork() {

        var res = _appointmentDoctorService.GetFreeAppointment(0);

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }

}
