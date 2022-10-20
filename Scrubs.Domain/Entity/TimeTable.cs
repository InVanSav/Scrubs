namespace Scrubs.Domain.Entity;

using Microsoft.EntityFrameworkCore;

[Keyless]
public class TimeTable {
    
    public int IdOfDoctor { get; set; }
    
    public DateTime StartOfWorkDayDoctor { get; set; }
    
    public DateTime FinishOfWorkDayDoctor { get; set; }
    
}
