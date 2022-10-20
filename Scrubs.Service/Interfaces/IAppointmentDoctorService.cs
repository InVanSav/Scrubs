namespace Scrubs.Service.Interfaces;

using Domain.Entity;
using Domain.Response;
using Domain.ViewModels.AppointmentDoctor;

public interface IAppointmentDoctorService {

    Task<IBaseResponse<AppointmentDoctor>> GetByIdPatient(int idPatient);

    Task<IBaseResponse<AppointmentDoctor>> GetByIdDoctor(int idDoctor);

    Task<IBaseResponse<AppointmentDoctor>> GetByDateOfStartAppointment(DateTime start);

    Task<IBaseResponse<AppointmentDoctor>> GetByDateOfFinishAppointment(DateTime finish);

    Task<IBaseResponse<IEnumerable<AppointmentDoctor>>> GetAppointments();

    Task<IBaseResponse<bool>> DeleteAppointment(int id);

    Task<IBaseResponse<AppointmentDoctorViewModel>> CreateAppointment(
        AppointmentDoctorViewModel appointmentDoctorViewModel
    );

    Task<IBaseResponse<AppointmentDoctor>> Edit(
        int id, AppointmentDoctorViewModel appointmentDoctor
    );

}
