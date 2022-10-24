namespace Scrubs.Service.Implementations;

using DAL.Interfaces;
using Domain.Entity;
using Domain.Enum;
using Domain.Response;
using Domain.ViewModels.Doctor;
using Interfaces;

public class DoctorService : IDoctorService {
    
    private readonly IDoctorRepository _doctorRepository;

    public DoctorService(IDoctorRepository doctorRepository) {
        _doctorRepository = doctorRepository;
    }
    
    public async Task<IBaseResponse<IEnumerable<Doctor>>> GetDoctors() {
        
        var baseResponse = new BaseResponse<IEnumerable<Doctor>>();

        try{

            var doctors = await _doctorRepository.Select();

            if (doctors.Count == 0){
                baseResponse.Result = "Doctors not found:(";
                baseResponse.StatusCode = StatusCode.DataNotFound;
                return baseResponse;
            }

            baseResponse.Data = doctors;
            baseResponse.StatusCode = StatusCode.OK;
            
            return baseResponse;
            
        } catch (Exception ex) {
            
            return new BaseResponse<IEnumerable<Doctor>>() {
                Result = $"[GetDoctors] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };
            
        }

    }
    
    public async Task<IBaseResponse<Doctor>> Get(int id) {

        var baseResponse = new BaseResponse<Doctor>();

        try{

            var doctor = await _doctorRepository.Get(id);

            if (doctor == null){
                baseResponse.Result = "Doctor not found:(";
                baseResponse.StatusCode = StatusCode.DataNotFound;
                return baseResponse;
            }

            baseResponse.Data = doctor;
            baseResponse.StatusCode = StatusCode.OK;
            
            return baseResponse;

        } catch (Exception ex){
            
            return new BaseResponse<Doctor>() {
                Result = $"[Get] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };
            
        }
        
    }

    public async Task<IBaseResponse<Doctor>> GetByFullName(string fullName) {

        var baseResponse = new BaseResponse<Doctor>();

        try{

            var doctor = await _doctorRepository.GetDoctorByFullName(fullName);

            if (doctor == null){
                baseResponse.Result = "Doctor not found:(";
                baseResponse.StatusCode = StatusCode.DataNotFound;
                return baseResponse;
            }

            baseResponse.Data = doctor;
            baseResponse.StatusCode = StatusCode.OK;
            
            return baseResponse;

        } catch (Exception ex){
            
            return new BaseResponse<Doctor>() {
                Result = $"[GetByFullName] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };
            
        }
        
    }

    public async Task<IBaseResponse<Doctor>> GetByJobTitle(string jobTitle) {

        var baseResponse = new BaseResponse<Doctor>();

        try{

            var doctor = await _doctorRepository.GetDoctorByJobTitle(jobTitle);

            if (doctor == null){
                baseResponse.Result = "Doctor not found:(";
                baseResponse.StatusCode = StatusCode.DataNotFound;
                return baseResponse;
            }

            baseResponse.Data = doctor;
            baseResponse.StatusCode = StatusCode.OK;
            
            return baseResponse;

        } catch (Exception ex){
            
            return new BaseResponse<Doctor>() {
                Result = $"[GetByJobTitle] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };
            
        }
        
    }

    public async Task<IBaseResponse<bool>> DeleteDoctor(int id) {
        
        var baseResponse = new BaseResponse<bool>();

        try{

            var doctor = await _doctorRepository.Get(id);

            if (doctor == null){
                baseResponse.Result = "Doctor not found:(";
                baseResponse.StatusCode = StatusCode.DataNotFound;
                return baseResponse;
            }

            await _doctorRepository.Delete(doctor);
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;

        } catch (Exception ex){
            
            return new BaseResponse<bool>() {
                Result = $"[DeleteDoctor] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };
            
        }
        
    }
    
    public async Task<IBaseResponse<DoctorViewModel>> CreateDoctor(DoctorViewModel doctorViewModel) {
        
        var baseResponse = new BaseResponse<DoctorViewModel>();

        try{

            var doctor = new Doctor() {
                JobTitle = doctorViewModel.JobTitle,
                FullName = doctorViewModel.FullName,
            };

            if (doctor == null){
                baseResponse.Result = "Doctor wasn't create:(";
                baseResponse.StatusCode = StatusCode.DataWasNotAdded;
                return baseResponse;
            }
            
            await _doctorRepository.Create(doctor);
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;

        } catch (Exception ex){
            
            return new BaseResponse<DoctorViewModel>() {
                Result = $"[CreateDoctor] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };
            
        }
        
    }
    
    public async Task<IBaseResponse<Doctor>> Edit(int id, DoctorViewModel doctorViewModel) {
        
        var baseResponse = new BaseResponse<Doctor>();

        try{

            var doctor = _doctorRepository.Get(id);

            if (doctor == null){
                baseResponse.StatusCode = StatusCode.DataNotFound;
                baseResponse.Result = "Doctor not found:(";
                return baseResponse;
            }

            doctor.Result.Id = doctorViewModel.Id;
            doctor.Result.JobTitle = doctorViewModel.JobTitle;
            doctor.Result.FullName = doctorViewModel.FullName;

            await _doctorRepository.Update(await doctor);

            return baseResponse;

        }
        catch (Exception ex) {
            
            return new BaseResponse<Doctor>() {
                Result = $"[Edit] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };
            
        }
        
    }
    
}
