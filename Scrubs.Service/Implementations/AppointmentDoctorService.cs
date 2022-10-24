namespace Scrubs.Service.Implementations;

using DAL.Interfaces;
using Domain.Entity;
using Domain.Enum;
using Domain.Response;
using Domain.ViewModels.AppointmentDoctor;
using Domain.ViewModels.User;
using Interfaces;

public class AppointmentDoctorService : IAppointmentDoctorService {
    
    private readonly IAppointmentDoctorRepository _appointmentDoctorRepository;

    public AppointmentDoctorService(IAppointmentDoctorRepository appointmentDoctorRepository) {
        _appointmentDoctorRepository = appointmentDoctorRepository;
    }

    public async Task<IBaseResponse<AppointmentDoctor>> GetByIdPatient(int idPatient) {

        var baseResponse = new BaseResponse<AppointmentDoctor>();

        try{

            var appointment = await _appointmentDoctorRepository.GetByIdOfPatient(idPatient);

            if (appointment == null){
                baseResponse.Result = "Appointment not found:(";
                baseResponse.StatusCode = StatusCode.DataNotFound;
                return baseResponse;
            }

            baseResponse.Data = appointment;
            baseResponse.StatusCode = StatusCode.OK;
            
            return baseResponse;

        } catch (Exception ex){
            
            return new BaseResponse<AppointmentDoctor>() {
                Result = $"[GetByIdPatient] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };
            
        }
        
    }
    
    public async Task<IBaseResponse<AppointmentDoctor>> GetByIdDoctor(int idDoctor) {

        var baseResponse = new BaseResponse<AppointmentDoctor>();

        try{

            var appointment = await _appointmentDoctorRepository.GetByIdOfDoctor(idDoctor);

            if (appointment == null){
                baseResponse.Result = "Appointment not found:(";
                baseResponse.StatusCode = StatusCode.DataNotFound;
                return baseResponse;
            }

            baseResponse.Data = appointment;
            baseResponse.StatusCode = StatusCode.OK;
            
            return baseResponse;

        } catch (Exception ex){
            
            return new BaseResponse<AppointmentDoctor>() {
                Result = $"[GetByIdDoctor] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };
            
        }
        
    }
    
    public async Task<IBaseResponse<AppointmentDoctor>> GetByDateOfStartAppointment(DateTime start) {

        var baseResponse = new BaseResponse<AppointmentDoctor>();

        try{

            var appointment = await _appointmentDoctorRepository.
                GetByDateOfStartAppointmentWithDoctor(start);

            if (appointment == null){
                baseResponse.Result = "Appointment not found:(";
                baseResponse.StatusCode = StatusCode.DataNotFound;
                return baseResponse;
            }

            baseResponse.Data = appointment;
            baseResponse.StatusCode = StatusCode.OK;
            
            return baseResponse;

        } catch (Exception ex){
            
            return new BaseResponse<AppointmentDoctor>() {
                Result = $"[GetByDateOfStartAppointment] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };
            
        }
        
    }
    
    public async Task<IBaseResponse<AppointmentDoctor>> GetByDateOfFinishAppointment(DateTime finish) {

        var baseResponse = new BaseResponse<AppointmentDoctor>();

        try{

            var appointment = await _appointmentDoctorRepository.
                GetByDateOfFinishAppointmentWithDoctor(finish);

            if (appointment == null){
                baseResponse.Result = "Appointment not found:(";
                baseResponse.StatusCode = StatusCode.DataNotFound;
                return baseResponse;
            }

            baseResponse.Data = appointment;
            baseResponse.StatusCode = StatusCode.OK;
            
            return baseResponse;

        } catch (Exception ex){
            
            return new BaseResponse<AppointmentDoctor>() {
                Result = $"[GetByDateOfFinishAppointment] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };
            
        }
        
    }

    public async Task<IBaseResponse<AppointmentDoctor>> GetFreeAppointment(int id) {

        var baseResponse = new BaseResponse<AppointmentDoctor>();

        try{

            var appointment = await _appointmentDoctorRepository.
                Get(id);

            if (appointment == null){
                baseResponse.Result = "Appointment not found:(";
                baseResponse.StatusCode = StatusCode.DataNotFound;
                return baseResponse;
            }

            baseResponse.Data = appointment;
            baseResponse.StatusCode = StatusCode.OK;
            
            return baseResponse;

        } catch (Exception ex){
            
            return new BaseResponse<AppointmentDoctor>() {
                Result = $"[GetFreeAppointment] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };
            
        }
        
    }

    public async Task<IBaseResponse<IEnumerable<AppointmentDoctor>>> GetAppointments() {
        
        var baseResponse = new BaseResponse<IEnumerable<AppointmentDoctor>>();

        try {

            var appointment = await _appointmentDoctorRepository.Select();

            if (appointment.Count == 0) {
                baseResponse.Result = "Appointments not found:(";
                baseResponse.StatusCode = StatusCode.DataNotFound;
                return baseResponse;
            }

            baseResponse.Data = appointment;
            baseResponse.StatusCode = StatusCode.OK;
            
            return baseResponse;
            
        } catch (Exception ex) {
            
            return new BaseResponse<IEnumerable<AppointmentDoctor>>() {
                Result = $"[GetAppointments] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };
            
        }

    }

    public async Task<IBaseResponse<bool>> DeleteAppointment(int id) {
        
        var baseResponse = new BaseResponse<bool>();

        try{

            var appointment = await _appointmentDoctorRepository.Get(id);

            if (appointment == null){
                baseResponse.Result = "Appointment not found:(";
                baseResponse.StatusCode = StatusCode.DataNotFound;
                return baseResponse;
            }

            await _appointmentDoctorRepository.Delete(appointment);
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;

        } catch (Exception ex){
            
            return new BaseResponse<bool>() {
                Result = $"[DeleteAppointment] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };
            
        }
        
    }
    
    public async Task<IBaseResponse<AppointmentDoctorViewModel>> CreateAppointment(
        AppointmentDoctorViewModel appointmentDoctorViewModel
        ) {
        
        var baseResponse = new BaseResponse<AppointmentDoctorViewModel>();

        try{

            var appointment = new AppointmentDoctor() {
                IdDoctor = appointmentDoctorViewModel.IdDoctor,
                IdPatient = appointmentDoctorViewModel.IdPatient,
                DateOfFinishAppointmentWithDoctor = 
                    appointmentDoctorViewModel.DateOfFinishAppointmentWithDoctor,
                DateOfStartAppointmentWithDoctor = 
                    appointmentDoctorViewModel.DateOfStartAppointmentWithDoctor,
                FreeTimeOfDoctor = appointmentDoctorViewModel.FreeTimeOfDoctor,
            };
            
            var find = _appointmentDoctorRepository.
                GetByDateOfStartAppointmentWithDoctor(appointment.FreeTimeOfDoctor);

            if (appointment == null) {
                baseResponse.Result = "Appointment wasn't create:(";
                baseResponse.StatusCode = StatusCode.DataWasNotAdded;
                return baseResponse;
            } if (appointment.FreeTimeOfDoctor == find.Result.FreeTimeOfDoctor) {
                baseResponse.Result = "Appointment wasn't create:(";
                baseResponse.StatusCode = StatusCode.DataWasNotAdded;
                return baseResponse;
            }

            await _appointmentDoctorRepository.Create(appointment);
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;

        } catch (Exception ex){
            
            return new BaseResponse<AppointmentDoctorViewModel>() {
                Result = $"[CreateAppointment] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };
            
        }
        
    }
    
    public async Task<IBaseResponse<AppointmentDoctor>> Edit(
        int id, AppointmentDoctorViewModel appointmentDoctor
        ) {
        
        var baseResponse = new BaseResponse<AppointmentDoctor>();

        try{

            var appointment = _appointmentDoctorRepository.Get(id);

            if (appointment == null){
                baseResponse.StatusCode = StatusCode.DataNotFound;
                baseResponse.Result = "Appointment not found:(";
                return baseResponse;
            }

            appointment.Result.IdDoctor = appointmentDoctor.IdDoctor;
            appointment.Result.IdPatient = appointmentDoctor.IdPatient;
            appointment.Result.DateOfFinishAppointmentWithDoctor =
                appointmentDoctor.DateOfFinishAppointmentWithDoctor;
            appointment.Result.DateOfStartAppointmentWithDoctor =
                appointmentDoctor.DateOfStartAppointmentWithDoctor;
            
            var find = _appointmentDoctorRepository.
                GetByDateOfStartAppointmentWithDoctor(appointment.Result.FreeTimeOfDoctor);
            
            if (appointment.Result.FreeTimeOfDoctor == find.Result.FreeTimeOfDoctor) {
                baseResponse.Result = "Appointment wasn't create:(";
                baseResponse.StatusCode = StatusCode.DataWasNotAdded;
                return baseResponse;
            }

            await _appointmentDoctorRepository.Update(await appointment);

            return baseResponse;

        }
        catch (Exception ex) {
            
            return new BaseResponse<AppointmentDoctor>() {
                Result = $"[Edit] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };
            
        }
        
    }
    
}
