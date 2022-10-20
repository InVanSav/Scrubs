namespace Scrubs.Service.Interfaces;

using Domain.Entity;
using Domain.Response;
using Domain.ViewModels.Doctor;

public interface IDoctorService {
    
    Task<IBaseResponse<IEnumerable<Doctor>>> GetDoctors();

    Task<IBaseResponse<Doctor>> Get(int id);

    Task<IBaseResponse<Doctor>> GetByFullName(string fullName);

    Task<IBaseResponse<Doctor>> GetByJobTitle(string jobTitle);

    Task<IBaseResponse<bool>> DeleteDoctor(int id);

    Task<IBaseResponse<DoctorViewModel>> CreateDoctor(DoctorViewModel doctorViewModel);

    Task<IBaseResponse<Doctor>> Edit(int id, DoctorViewModel doctorViewModel);

}
