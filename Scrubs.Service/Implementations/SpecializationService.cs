namespace Scrubs.Service.Implementations;

using DAL.Interfaces;
using Domain.Entity;
using Domain.Enum;
using Domain.Response;
using Domain.ViewModels.Specialization;
using Interfaces;

public class SpecializationService : ISpecializationService {

    private readonly ISpecializationRepository _specializationRepository;

    public SpecializationService(ISpecializationRepository specializationRepository) {
        _specializationRepository = specializationRepository;
    }
    
    public async Task<IBaseResponse<IEnumerable<Specialization>>> GetSpecializations() {
        
        var baseResponse = new BaseResponse<IEnumerable<Specialization>>();

        try{

            var specializations = await _specializationRepository.Select();

            if (specializations.Count == 0){
                baseResponse.Result = "Specializations not found:(";
                baseResponse.StatusCode = StatusCode.DataNotFound;
                return baseResponse;
            }

            baseResponse.Data = specializations;
            baseResponse.StatusCode = StatusCode.OK;
            
            return baseResponse;
            
        } catch (Exception ex) {
            
            return new BaseResponse<IEnumerable<Specialization>>() {
                Result = $"[GetSpecialization] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };
            
        }
        
    }
    
    public async Task<IBaseResponse<Specialization>> GetByName(string name) {

        var baseResponse = new BaseResponse<Specialization>();

        try{

            var specialization = await _specializationRepository.GetSpecializationByName(name);

            if (specialization == null){
                baseResponse.Result = "Specialization not found:(";
                baseResponse.StatusCode = StatusCode.DataNotFound;
                return baseResponse;
            }

            baseResponse.Data = specialization;
            baseResponse.StatusCode = StatusCode.OK;
            
            return baseResponse;

        } catch (Exception ex){
            
            return new BaseResponse<Specialization>() {
                Result = $"[GetByName] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };
            
        }
        
    }
    
    public async Task<IBaseResponse<Specialization>> Get(int id) {

        var baseResponse = new BaseResponse<Specialization>();

        try{

            var specialization = await _specializationRepository.Get(id);

            if (specialization == null){
                baseResponse.Result = "Specialization not found:(";
                baseResponse.StatusCode = StatusCode.DataNotFound;
                return baseResponse;
            }

            baseResponse.Data = specialization;
            baseResponse.StatusCode = StatusCode.OK;
            
            return baseResponse;

        } catch (Exception ex){
            
            return new BaseResponse<Specialization>() {
                Result = $"[Get] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };
            
        }
        
    }
    
    public async Task<IBaseResponse<bool>> DeleteSpecialization(int id) {
        
        var baseResponse = new BaseResponse<bool>();

        try{

            var specialization = await _specializationRepository.Get(id);

            if (specialization == null){
                baseResponse.Result = "Specialization not found:(";
                baseResponse.StatusCode = StatusCode.DataNotFound;
                return baseResponse;
            }

            await _specializationRepository.Delete(specialization);
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;

        } catch (Exception ex){
            
            return new BaseResponse<bool>() {
                Result = $"[DeleteSpecialization] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };
            
        }
        
    }
    
    public async Task<IBaseResponse<SpecializationViewModel>> CreateSpecialization(
        SpecializationViewModel specializationViewModel
        ) {
        
        var baseResponse = new BaseResponse<SpecializationViewModel>();

        try{

            var specialization = new Specialization() {
                Name = specializationViewModel.Name,
            };

            if (specialization == null){
                baseResponse.Result = "Specialization wasn't create:(";
                baseResponse.StatusCode = StatusCode.DataWasNotAdded;
                return baseResponse;
            }
            
            await _specializationRepository.Create(specialization);
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;

        } catch (Exception ex){
            
            return new BaseResponse<SpecializationViewModel>() {
                Result = $"[CreateSpecialization] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };
            
        }
        
    }
    
    public async Task<IBaseResponse<Specialization>> Edit(
        int id, SpecializationViewModel specializationViewModel
        ) {
        
        var baseResponse = new BaseResponse<Specialization>();

        try{

            var specialization = _specializationRepository.Get(id);

            if (specialization == null){
                baseResponse.StatusCode = StatusCode.DataNotFound;
                baseResponse.Result = "Specialization not found:(";
                return baseResponse;
            }

            specialization.Result.Id = specializationViewModel.Id;
            specialization.Result.Name = specializationViewModel.Name;

            await _specializationRepository.Update(await specialization);

            return baseResponse;

        }
        catch (Exception ex) {
            
            return new BaseResponse<Specialization>() {
                Result = $"[Edit] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };
            
        }
        
    }
    
}
