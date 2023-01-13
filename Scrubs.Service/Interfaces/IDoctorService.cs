namespace Scrubs.Service.Interfaces;

using Domain.Entity;
using Domain.Response;

public interface IDoctorService {
    
    Task<IBaseResponse<IEnumerable<Doctor>>> GetDoctors();

    Task<IBaseResponse<Doctor>> Get(int id);

    Task<IBaseResponse<Doctor>> GetByFullName(string fullName);

    Task<IBaseResponse<Doctor>> GetByJobTitle(string jobTitle);

    Task<IBaseResponse<bool>> DeleteDoctor(int id);

    Task<IBaseResponse<Doctor>> CreateDoctor(Doctor doctor);

    Task<IBaseResponse<Doctor>> Edit(int id, Doctor doctor);

}
