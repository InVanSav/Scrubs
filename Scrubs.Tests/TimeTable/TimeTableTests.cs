namespace Scrubs.Tests.TimeTable;

using Domain.ViewModels.TimeTable;
using Service.Implementations;

public class TimeTableTests {

    private  readonly  TimeTableService _timeTableService;

    public TimeTableTests(TimeTableService timeTableService) {
        _timeTableService = timeTableService;
    }
    
    [Fact] 
    public void GetTimeTableOrNo_ShouldFail() {

        var res = _timeTableService.GetTimeTable(0);

        Assert.True(res.IsFaulted);
        Assert.Equal("TimeTable not found:(", res.Result.Result);
        Assert.Equal(6, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void GetTimeTablesOrNo_ShouldFail() {

        var res = _timeTableService.GetTimeTables();

        Assert.True(res.IsFaulted);
        Assert.Equal("TimeTables not found:(", res.Result.Result);
        Assert.Equal(6, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void GetTimeTableByStartOfWorkDayDoctorOrNo_ShouldFail() {

        var res = _timeTableService.GetByStartOfWorkDayDoctor(DateTime.Now);

        Assert.True(res.IsFaulted);
        Assert.Equal("TimeTable not found:(", res.Result.Result);
        Assert.Equal(6, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void GetTimeTableByFinishOfWorkDayDoctorOrNo_ShouldFail() {

        var res = _timeTableService.GetByFinishOfWorkDayDoctor(DateTime.Today);

        Assert.True(res.IsFaulted);
        Assert.Equal("TimeTable not found:(", res.Result.Result);
        Assert.Equal(6, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void DeleteTimeTableOrNo_ShouldFail() {

        var res = _timeTableService.DeleteTimeTable(0);

        Assert.True(res.IsFaulted);
        Assert.Equal("TimeTable not found:(", res.Result.Result);
        Assert.Equal(6, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void CreateTimeTableOrNo_ShouldFail() {

        var timeTable = new TimeTableViewModel {
            IdOfDoctor = 0,
            StartOfWorkDayDoctor = DateTime.Now,
            FinishOfWorkDayDoctor = DateTime.Today
        };

        var res = _timeTableService.CreateTimeTable(timeTable);

        Assert.True(res.IsFaulted);
        Assert.Equal("TimeTable not found:(", res.Result.Result);
        Assert.Equal(6, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void EditTimeTableOrNo_ShouldFail() {

        var timeTable = new TimeTableViewModel {
            IdOfDoctor = 0,
            StartOfWorkDayDoctor = DateTime.Now,
            FinishOfWorkDayDoctor = DateTime.Today
        };

        var res = _timeTableService.Edit(0, timeTable);

        Assert.True(res.IsFaulted);
        Assert.Equal("TimeTable not found:(", res.Result.Result);
        Assert.Equal(6, (int)res.Result.StatusCode);

    }
    
}
