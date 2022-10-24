namespace Scrubs.Domain.ViewModels.AppointmentDoctor;

using Entity;

public class AppointmentDoctorViewModel {
    
    public DateTime DateOfStartAppointmentWithDoctor { get; set; }

    public DateTime DateOfFinishAppointmentWithDoctor { get; set; }
    
    public DateTime FreeTimeOfDoctor { get; set; }

    public int IdPatient { get; set; }
    
    public int IdDoctor { get; set; }
    
}
