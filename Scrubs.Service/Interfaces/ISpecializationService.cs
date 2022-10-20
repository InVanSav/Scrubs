namespace Scrubs.Service.Interfaces;

using Domain.Entity;
using Domain.Response;
using Domain.ViewModels.Specialization;

public interface ISpecializationService {
    
    Task<IBaseResponse<IEnumerable<Specialization>>> GetSpecializations();

    Task<IBaseResponse<Specialization>> GetByName(string name);

    Task<IBaseResponse<SpecializationViewModel>> CreateSpecialization(
        SpecializationViewModel specializationViewModel
    );

    Task<IBaseResponse<bool>> DeleteSpecialization(int id);

    Task<IBaseResponse<Specialization>> Get(int id);

    Task<IBaseResponse<Specialization>> Edit(
        int id, SpecializationViewModel specializationViewModel
    );

}
