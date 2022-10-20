namespace Scrubs.Domain.ViewModels.AppointmentDoctor; 

public class AppointmentDoctorViewModel {
    
    public DateTime DateOfStartAppointmentWithDoctor { get; set; }

    public DateTime DateOfFinishAppointmentWithDoctor { get; set; }

    public int IdPatient { get; set; }
    
    public int IdDoctor { get; set; }
    
}
