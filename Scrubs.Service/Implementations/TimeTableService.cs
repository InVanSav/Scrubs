namespace Scrubs.Service.Implementations;

using DAL.Interfaces;
using Domain.Entity;
using Domain.Enum;
using Domain.Response;
using Domain.ViewModels.TimeTable;
using Interfaces;

public class TimeTableService : ITimeTableService{
    
    private readonly ITimeTableRepository _timeTableRepository;

    public TimeTableService(ITimeTableRepository timeTableRepository) {
        _timeTableRepository = timeTableRepository;
    }
    
    public async Task<IBaseResponse<TimeTable>> GetTimeTable(int id) {

        var baseResponse = new BaseResponse<TimeTable>();

        try{

            var timeTable = await _timeTableRepository.Get(id);

            if (timeTable == null){
                baseResponse.Result = "TimeTable not found:(";
                baseResponse.StatusCode = StatusCode.DataNotFound;
                return baseResponse;
            }

            baseResponse.Data = timeTable;
            baseResponse.StatusCode = StatusCode.OK;
            
            return baseResponse;

        } catch (Exception ex){
            
            return new BaseResponse<TimeTable>() {
                Result = $"[GetTimeTable] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };
            
        }
        
    }

    public async Task<IBaseResponse<IEnumerable<TimeTable>>> GetTimeTables() {
        
        var baseResponse = new BaseResponse<IEnumerable<TimeTable>>();

        try {

            var timeTables = await _timeTableRepository.Select();

            if (timeTables.Count == 0) {
                baseResponse.Result = "TimeTables not found:(";
                baseResponse.StatusCode = StatusCode.DataNotFound;
                return baseResponse;
            }

            baseResponse.Data = timeTables;
            baseResponse.StatusCode = StatusCode.OK;
            
            return baseResponse;
            
        } catch (Exception ex) {
            
            return new BaseResponse<IEnumerable<TimeTable>>() {
                Result = $"[GetTimeTables] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };
            
        }
        
    }
    
    public async Task<IBaseResponse<TimeTable>> GetByStartOfWorkDayDoctor(DateTime start) {

        var baseResponse = new BaseResponse<TimeTable>();

        try{

            var timeTable = await _timeTableRepository.GetByStartOfWorkDayDoctor(start);

            if (timeTable == null){
                baseResponse.Result = "TimeTable not found:(";
                baseResponse.StatusCode = StatusCode.DataNotFound;
                return baseResponse;
            }

            baseResponse.Data = timeTable;
            baseResponse.StatusCode = StatusCode.OK;
            
            return baseResponse;

        } catch (Exception ex){
            
            return new BaseResponse<TimeTable>() {
                Result = $"[GetByStartOfWorkDayDoctor] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };
            
        }
        
    }
    
    public async Task<IBaseResponse<TimeTable>> GetByFinishOfWorkDayDoctor(DateTime finish) {

        var baseResponse = new BaseResponse<TimeTable>();

        try{

            var timeTable = await _timeTableRepository.GetByFinishOfWorkDayDoctor(finish);

            if (timeTable == null){
                baseResponse.Result = "TimeTable not found:(";
                baseResponse.StatusCode = StatusCode.DataNotFound;
                return baseResponse;
            }

            baseResponse.Data = timeTable;
            baseResponse.StatusCode = StatusCode.OK;
            
            return baseResponse;

        } catch (Exception ex){
            
            return new BaseResponse<TimeTable>() {
                Result = $"[GetByFinishOfWorkDayDoctor] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };
            
        }
        
    }
    
    public async Task<IBaseResponse<bool>> DeleteTimeTable(int id) {
        
        var baseResponse = new BaseResponse<bool>();

        try{

            var timeTable = await _timeTableRepository.Get(id);

            if (timeTable == null){
                baseResponse.Result = "TimeTable not found:(";
                baseResponse.StatusCode = StatusCode.DataNotFound;
                return baseResponse;
            }

            await _timeTableRepository.Delete(timeTable);
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;

        } catch (Exception ex){
            
            return new BaseResponse<bool>() {
                Result = $"[DeleteTimaTable] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };
            
        }
        
    }
    
    public async Task<IBaseResponse<TimeTableViewModel>> CreateTimeTable(TimeTableViewModel timeTableViewModel) {
        
        var baseResponse = new BaseResponse<TimeTableViewModel>();

        try{

            var timeTable = new TimeTable() {
                IdOfDoctor = timeTableViewModel.IdOfDoctor,
                FinishOfWorkDayDoctor = timeTableViewModel.FinishOfWorkDayDoctor,
                StartOfWorkDayDoctor = timeTableViewModel.StartOfWorkDayDoctor,
            };

            if (timeTable == null){
                baseResponse.Result = "TimeTable wasn't create:(";
                baseResponse.StatusCode = StatusCode.DataWasNotAdded;
                return baseResponse;
            }
            
            await _timeTableRepository.Create(timeTable);
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;

        } catch (Exception ex){
            
            return new BaseResponse<TimeTableViewModel>() {
                Result = $"[CreateTimeTable] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };
            
        }
        
    }
    
    public async Task<IBaseResponse<TimeTable>> Edit(int id, TimeTableViewModel timeTableViewModel) {
        
        var baseResponse = new BaseResponse<TimeTable>();

        try{

            var timeTable = _timeTableRepository.Get(id);

            if (timeTable == null){
                baseResponse.StatusCode = StatusCode.DataNotFound;
                baseResponse.Result = "TimeTable not found:(";
                return baseResponse;
            }

            timeTable.Result.IdOfDoctor = timeTableViewModel.IdOfDoctor;
            timeTable.Result.StartOfWorkDayDoctor = timeTableViewModel.StartOfWorkDayDoctor;
            timeTable.Result.FinishOfWorkDayDoctor = timeTableViewModel.FinishOfWorkDayDoctor;

            await _timeTableRepository.Update(await timeTable);

            return baseResponse;

        }
        catch (Exception ex) {
            
            return new BaseResponse<TimeTable>() {
                Result = $"[Edit] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };
            
        }
        
    }
    
}
