namespace Scrubs.DAL.Interfaces;

using Domain.Entity;

public interface IAppointmentDoctorRepository : IBaseRepository<AppointmentDoctor> {
    
    Task<AppointmentDoctor> GetByDateOfStartAppointmentWithDoctor(DateTime start);

    Task<AppointmentDoctor> GetByDateOfFinishAppointmentWithDoctor(DateTime finish);

    Task<AppointmentDoctor> GetByIdOfPatient(int id);

    Task<AppointmentDoctor> GetByIdOfDoctor(int id);
    
}
