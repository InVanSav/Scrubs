namespace Scrubs.Tests.AppointmentDoctor;

using Domain.ViewModels.AppointmentDoctor;
using Service.Implementations;

public class AppointmentDoctorTests {

    private readonly AppointmentDoctorService _appointmentDoctorService;

    public AppointmentDoctorTests(AppointmentDoctorService appointmentDoctorService) {
        _appointmentDoctorService = appointmentDoctorService;
    }
    
    [Fact] 
    public void GetAppointmentsOrNo_ShouldFail() {

        var res = _appointmentDoctorService.GetAppointments();

        Assert.True(res.IsFaulted);
        Assert.Equal("Appointments not found:(", res.Result.Result);
        Assert.Equal(8, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void GetAppointmentByIdPatientOrNo_ShouldFail() {

        var res = _appointmentDoctorService.GetByIdPatient(0);

        Assert.True(res.IsFaulted);
        Assert.Equal("Appointment not found:(", res.Result.Result);
        Assert.Equal(8, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void GetAppointmentByIdDoctorOrNo_ShouldFail() {

        var res = _appointmentDoctorService.GetByIdDoctor(0);

        Assert.True(res.IsFaulted);
        Assert.Equal("Appointment not found:(", res.Result.Result);
        Assert.Equal(8, (int)res.Result.StatusCode);

    }

    [Fact] public void GetAppointmentByDayOfStartOrNo_ShouldFail() {

        var res = _appointmentDoctorService.GetByDateOfStartAppointment(DateTime.Now);

        Assert.True(res.IsFaulted);
        Assert.Equal("Appointment not found:(", res.Result.Result);
        Assert.Equal(8, (int)res.Result.StatusCode);

    }

    [Fact] 
    public void GetAppointmentByDayOfFinishOrNo_ShouldFail() {

        var res = _appointmentDoctorService.GetByDateOfFinishAppointment(DateTime.Today);

        Assert.True(res.IsFaulted);
        Assert.Equal("Appointment not found:(", res.Result.Result);
        Assert.Equal(8, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void DeleteAppointmentOrNo_ShouldFail() {

        var res = _appointmentDoctorService.DeleteAppointment(0);

        Assert.True(res.IsFaulted);
        Assert.Equal("Appointment not found:(", res.Result.Result);
        Assert.Equal(8, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void CreateAppointmentOrNo_ShouldFail() {

        var appointment = new AppointmentDoctorViewModel {
            IdDoctor = 0,
            IdPatient = 0,
            DateOfStartAppointmentWithDoctor = DateTime.Now,
            DateOfFinishAppointmentWithDoctor = DateTime.Today
        };

        var res = _appointmentDoctorService.CreateAppointment(appointment);

        Assert.True(res.IsFaulted);
        Assert.Equal("Appointment not found:(", res.Result.Result);
        Assert.Equal(8, (int)res.Result.StatusCode);

    }

    [Fact] 
    public void EditAppointmentOrNo_ShouldFail() {

        var appointment = new AppointmentDoctorViewModel {
            IdDoctor = 0,
            IdPatient = 0,
            DateOfStartAppointmentWithDoctor = DateTime.Now,
            DateOfFinishAppointmentWithDoctor = DateTime.Today
        };

        var res = _appointmentDoctorService.Edit(0, appointment);

        Assert.True(res.IsFaulted);
        Assert.Equal("Appointment not found:(", res.Result.Result);
        Assert.Equal(8, (int)res.Result.StatusCode);

    }

}
