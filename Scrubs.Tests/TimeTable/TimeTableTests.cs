namespace Scrubs.Tests.TimeTable;

using DAL.Interfaces;
using Domain.ViewModels.TimeTable;
using Service.Implementations;

public class TimeTableTests {

    private  readonly  TimeTableService _timeTableService;

    public TimeTableTests() {
        var timeTableRepositoryMock = new Mock<ITimeTableRepository>();
        _timeTableService = new TimeTableService(timeTableRepositoryMock.Object);
    }
    
    [Fact] 
    public void GetTimeTableOrNo_ShouldWork() {

        var res = _timeTableService.GetTimeTable(0);

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void GetTimeTablesOrNo_ShouldWork() {

        var res = _timeTableService.GetTimeTables();

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void GetTimeTableByStartOfWorkDayDoctorOrNo_ShouldFail() {

        var res = _timeTableService.GetByStartOfWorkDayDoctor(DateTime.Now);

        Assert.True(res.IsFaulted);
        Assert.Equal("TimeTable not found:(", res.Result.Result);
        Assert.Equal(0, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void GetTimeTableByFinishOfWorkDayDoctorOrNo_ShouldWork() {

        var res = _timeTableService.GetByFinishOfWorkDayDoctor(DateTime.Today);

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void DeleteTimeTableOrNo_ShouldWork() {

        var res = _timeTableService.DeleteTimeTable(0);

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void CreateTimeTableOrNo_ShouldWork() {

        var timeTable = new TimeTableViewModel {
            IdOfDoctor = 0,
            StartOfWorkDayDoctor = DateTime.Now,
            FinishOfWorkDayDoctor = DateTime.Today
        };

        var res = _timeTableService.CreateTimeTable(timeTable);

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void EditTimeTableOrNo_ShouldWork() {

        var timeTable = new TimeTableViewModel {
            IdOfDoctor = 0,
            StartOfWorkDayDoctor = DateTime.Now,
            FinishOfWorkDayDoctor = DateTime.Today
        };

        var res = _timeTableService.Edit(0, timeTable);

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }
    
}
