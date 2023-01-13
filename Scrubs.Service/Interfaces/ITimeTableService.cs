namespace Scrubs.Service.Interfaces;

using Domain.Entity;
using Domain.Response;

public interface ITimeTableService {
    
    Task<IBaseResponse<IEnumerable<TimeTable>>> GetTimeTables();

    Task<IBaseResponse<TimeTable>> GetTimeTable(int id);

    Task<IBaseResponse<TimeTable>> GetByStartOfWorkDayDoctor(DateTime start);

    Task<IBaseResponse<TimeTable>> GetByFinishOfWorkDayDoctor(DateTime finish);

    Task<IBaseResponse<bool>> DeleteTimeTable(int id);

    Task<IBaseResponse<TimeTable>> CreateTimeTable(TimeTable timeTable);

    Task<IBaseResponse<TimeTable>> Edit(int id, TimeTable timeTable);

}
