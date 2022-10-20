namespace Scrubs.DAL.Interfaces;

using Domain.Entity;

public interface IDoctorRepository : IBaseRepository<Doctor> {

    Task<Doctor> GetDoctorByFullName(string fullName);

    Task<Doctor> GetDoctorByJobTitle(string jobTitle);

}
