namespace Scrubs.DAL.Interfaces;

using Domain.Entity;

public interface ITimeTableRepository : IBaseRepository<TimeTable> {

    Task<TimeTable> GetByStartOfWorkDayDoctor(DateTime start);

    Task<TimeTable> GetByFinishOfWorkDayDoctor(DateTime finish);

}
