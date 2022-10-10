namespace Scrubs.Domain.Entity; 

public class TimeTable {
    
    public int IdOfDoctor { get; set; }
    
    public DateTime StartOfWorkDayDoctor { get; set; }
    
    public DateTime FinishOfWorkDayDoctor { get; set; }
    
}
