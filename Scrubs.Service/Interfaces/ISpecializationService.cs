namespace Scrubs.Service.Interfaces;

using Domain.Entity;
using Domain.Response;

public interface ISpecializationService {

    Task<IBaseResponse<IEnumerable<Specialization>>> GetSpecializations();

    Task<IBaseResponse<Specialization>> GetByName(string name);

    Task<IBaseResponse<Specialization>> CreateSpecialization(
        Specialization specialization
    );

    Task<IBaseResponse<bool>> DeleteSpecialization(int id);

    Task<IBaseResponse<Specialization>> Get(int id);

    Task<IBaseResponse<Specialization>> Edit(
        int id, Specialization specialization
    );

}
