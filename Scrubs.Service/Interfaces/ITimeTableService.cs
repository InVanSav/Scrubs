namespace Scrubs.Service.Interfaces;

using Domain.Entity;
using Domain.Response;
using Domain.ViewModels.TimeTable;

public interface ITimeTableService {
    
    Task<IBaseResponse<IEnumerable<TimeTable>>> GetTimeTables();

    Task<IBaseResponse<TimeTable>> GetTimeTable(int id);

    Task<IBaseResponse<TimeTable>> GetByStartOfWorkDayDoctor(DateTime start);

    Task<IBaseResponse<TimeTable>> GetByFinishOfWorkDayDoctor(DateTime finish);

    Task<IBaseResponse<bool>> DeleteTimeTable(int id);

    Task<IBaseResponse<TimeTableViewModel>> CreateTimeTable(TimeTableViewModel timeTableViewModel);

    Task<IBaseResponse<TimeTable>> Edit(int id, TimeTableViewModel timeTableViewModel);

}
