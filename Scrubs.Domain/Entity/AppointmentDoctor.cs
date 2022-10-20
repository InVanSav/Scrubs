namespace Scrubs.Domain.Entity;

using Microsoft.EntityFrameworkCore;

[Keyless]
public class AppointmentDoctor {

    public DateTime DateOfStartAppointmentWithDoctor { get; set; }

    public DateTime DateOfFinishAppointmentWithDoctor { get; set; }

    public int IdPatient { get; set; }
    
    public int IdDoctor { get; set; }

}
