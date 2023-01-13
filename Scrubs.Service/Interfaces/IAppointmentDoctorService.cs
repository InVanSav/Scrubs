namespace Scrubs.Service.Interfaces;

using Domain.Entity;
using Domain.Response;

public interface IAppointmentDoctorService {

    Task<IBaseResponse<AppointmentDoctor>> GetByIdPatient(int idPatient);

    Task<IBaseResponse<AppointmentDoctor>> GetByIdDoctor(int idDoctor);

    Task<IBaseResponse<AppointmentDoctor>> GetByDateOfStartAppointment(DateTime start);

    Task<IBaseResponse<AppointmentDoctor>> GetByDateOfFinishAppointment(DateTime finish);

    Task<IBaseResponse<AppointmentDoctor>> GetFreeAppointment(int id);

    Task<IBaseResponse<IEnumerable<AppointmentDoctor>>> GetAppointments();

    Task<IBaseResponse<bool>> DeleteAppointment(int id);

    Task<IBaseResponse<AppointmentDoctor>> CreateAppointment(
        AppointmentDoctor appointmentDoctor
    );

    Task<IBaseResponse<AppointmentDoctor>> Edit(
        int id, AppointmentDoctor appointmentDoctor
    );

}
