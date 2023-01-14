namespace Scrubs.Service.Implementations;

using DAL.Interfaces;
using Domain.Entity;
using Domain.Enum;
using Domain.Response;
using Interfaces;

public class TimeTableService : ITimeTableService {

    private readonly ITimeTableRepository _timeTableRepository;

    public TimeTableService(ITimeTableRepository timeTableRepository) {
        _timeTableRepository = timeTableRepository;
    }

    public async Task<IBaseResponse<TimeTable>> GetTimeTable(int id) {

        var baseResponse = new BaseResponse<TimeTable>();

        try {

            var timeTable = await _timeTableRepository.Get(id);

            if (timeTable == null) {
                baseResponse.Result = "TimeTable not found:(";
                baseResponse.StatusCode = StatusCode.DataNotFound;
                return baseResponse;
            }

            baseResponse.Data = timeTable;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;

        } catch (Exception ex) {

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

        try {

            var timeTable = await _timeTableRepository.GetByStartOfWorkDayDoctor(start);

            if (timeTable == null) {
                baseResponse.Result = "TimeTable not found:(";
                baseResponse.StatusCode = StatusCode.DataNotFound;
                return baseResponse;
            }

            baseResponse.Data = timeTable;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;

        } catch (Exception ex) {

            return new BaseResponse<TimeTable>() {
                Result = $"[GetByStartOfWorkDayDoctor] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };

        }

    }

    public async Task<IBaseResponse<TimeTable>> GetByFinishOfWorkDayDoctor(DateTime finish) {

        var baseResponse = new BaseResponse<TimeTable>();

        try {

            var timeTable = await _timeTableRepository.GetByFinishOfWorkDayDoctor(finish);

            if (timeTable == null) {
                baseResponse.Result = "TimeTable not found:(";
                baseResponse.StatusCode = StatusCode.DataNotFound;
                return baseResponse;
            }

            baseResponse.Data = timeTable;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;

        } catch (Exception ex) {

            return new BaseResponse<TimeTable>() {
                Result = $"[GetByFinishOfWorkDayDoctor] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };

        }

    }

    public async Task<IBaseResponse<bool>> DeleteTimeTable(int id) {

        var baseResponse = new BaseResponse<bool>();

        try {

            var timeTable = await _timeTableRepository.Get(id);

            if (timeTable == null) {
                baseResponse.Result = "TimeTable not found:(";
                baseResponse.StatusCode = StatusCode.DataNotFound;
                return baseResponse;
            }

            await _timeTableRepository.Delete(timeTable);
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;

        } catch (Exception ex) {

            return new BaseResponse<bool>() {
                Result = $"[DeleteTimaTable] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };

        }

    }

    public async Task<IBaseResponse<TimeTable>> CreateTimeTable(TimeTable timeTable) {

        var baseResponse = new BaseResponse<TimeTable>();

        try {

            var timeTablee = new TimeTable() {
                IdOfDoctor = timeTable.IdOfDoctor,
                FinishOfWorkDayDoctor = timeTable.FinishOfWorkDayDoctor,
                StartOfWorkDayDoctor = timeTable.StartOfWorkDayDoctor,
            };

            if (timeTablee == null) {
                baseResponse.Result = "TimeTable wasn't create:(";
                baseResponse.StatusCode = StatusCode.DataWasNotAdded;
                return baseResponse;
            }

            await _timeTableRepository.Create(timeTablee);
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;

        } catch (Exception ex) {

            return new BaseResponse<TimeTable>() {
                Result = $"[CreateTimeTable] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };

        }

    }

    public async Task<IBaseResponse<TimeTable>> Edit(int id, TimeTable timeTable) {

        var baseResponse = new BaseResponse<TimeTable>();

        try {

            var timeTablee = await _timeTableRepository.Get(id);

            if (timeTablee == null) {
                baseResponse.StatusCode = StatusCode.DataNotFound;
                baseResponse.Result = "TimeTable not found:(";
                return baseResponse;
            }

            timeTablee.IdOfDoctor = timeTable.IdOfDoctor;
            timeTablee.StartOfWorkDayDoctor = timeTable.StartOfWorkDayDoctor;
            timeTablee.FinishOfWorkDayDoctor = timeTable.FinishOfWorkDayDoctor;

            await _timeTableRepository.Update(timeTablee);

            return baseResponse;

        } catch (Exception ex) {

            return new BaseResponse<TimeTable>() {
                Result = $"[Edit] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };

        }

    }

}
