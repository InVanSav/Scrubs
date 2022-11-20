namespace Scrubs.Tests.TimeTable;

using DAL.Interfaces;
using Domain.Entity;
using Domain.ViewModels.TimeTable;
using Service.Implementations;

public class TimeTableTests {

    private  readonly  TimeTableService _timeTableService;
    private readonly Mock<ITimeTableRepository> _timeTableRepositoryMock;

    public TimeTableTests() {
        _timeTableRepositoryMock = new Mock<ITimeTableRepository>();
        _timeTableService = new TimeTableService(_timeTableRepositoryMock.Object);
    }
    
    [Fact] 
    public void GetTimeTableOrNo_ShouldWork() {
        
        var timeTable = new TimeTableViewModel {
            IdOfDoctor = 0,
            StartOfWorkDayDoctor = DateTime.Now,
            FinishOfWorkDayDoctor = DateTime.Today
        };
        
        _timeTableRepositoryMock.Setup(repository => repository.Get(0))
            .Returns(() => timeTable);

        var res = _timeTableService.GetTimeTable(0);

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void GetTimeTablesOrNo_ShouldWork() {
        
        var timeTable = new TimeTableViewModel {
            IdOfDoctor = 0,
            StartOfWorkDayDoctor = DateTime.Now,
            FinishOfWorkDayDoctor = DateTime.Today
        };
        
        _timeTableRepositoryMock.Setup(repository => repository.Select())
            .Returns(() => timeTable);

        var res = _timeTableService.GetTimeTables();

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void GetTimeTableByStartOfWorkDayDoctorOrNo_ShouldFail() {
        
        _timeTableRepositoryMock.Setup(
            repository => repository.GetByStartOfWorkDayDoctor(It.IsAny<DateTime>()))
            .Returns(() => null);

        var res = _timeTableService.GetByStartOfWorkDayDoctor(DateTime.Now);

        Assert.True(res.IsFaulted);
        Assert.Equal("TimeTable not found:(", res.Result.Result);
        Assert.Equal(0, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void GetTimeTableByFinishOfWorkDayDoctorOrNo_ShouldWork() {
        
        var timeTable = new TimeTableViewModel {
            IdOfDoctor = 0,
            StartOfWorkDayDoctor = DateTime.Now,
            FinishOfWorkDayDoctor = DateTime.Today
        };
        
        _timeTableRepositoryMock.Setup(
            repository => repository.GetByFinishOfWorkDayDoctor(DateTime.Today))
            .Returns(() => timeTable);

        var res = _timeTableService.GetByFinishOfWorkDayDoctor(DateTime.Today);

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void DeleteTimeTableOrNo_ShouldWork() {
        
        var timeTable = new TimeTable {
            IdOfDoctor = 0,
            StartOfWorkDayDoctor = DateTime.Now,
            FinishOfWorkDayDoctor = DateTime.Today
        };
        
        _timeTableRepositoryMock.Setup(repository => repository.Delete(timeTable))
            .Returns(() => true);

        var res = _timeTableService.DeleteTimeTable(0);

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void CreateTimeTableOrNo_ShouldWork() {

        var timeTable = new TimeTable {
            IdOfDoctor = 0,
            StartOfWorkDayDoctor = DateTime.Now,
            FinishOfWorkDayDoctor = DateTime.Today
        };
        
        _timeTableRepositoryMock.Setup(repository => repository.Create(timeTable))
            .Returns(() => true);


        var res = _timeTableService.CreateTimeTable(timeTable);

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void EditTimeTableOrNo_ShouldWork() {

        var timeTable = new TimeTable {
            IdOfDoctor = 0,
            StartOfWorkDayDoctor = DateTime.Now,
            FinishOfWorkDayDoctor = DateTime.Today
        };
        
        _timeTableRepositoryMock.Setup(repository => repository.Update(timeTable))
            .Returns(() => true);

        var res = _timeTableService.Edit(0, timeTable);

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }
    
}
