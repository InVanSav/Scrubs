namespace Scrubs.DAL.Repositories;

using Domain.Entity;
using Interfaces;
using Microsoft.EntityFrameworkCore;

public class TimeTableRepository : ITimeTableRepository{
    
    private readonly ApplicationDbContext _db;

    public TimeTableRepository(ApplicationDbContext db) {
        _db = db;
    }

    public async Task<bool> Create(TimeTable entity) {
        await _db.TimeTables.AddAsync(entity);
        await _db.SaveChangesAsync();

        return true;
    }
    
    public async Task<TimeTable> Get(int id) {
        return await _db.TimeTables.FirstOrDefaultAsync(x => x.IdOfDoctor == id);
    }
    
    public async Task<List<TimeTable>> Select() {
        return await _db.TimeTables.ToListAsync();
    }
    
    public async Task<bool> Delete(TimeTable entity) {
        _db.TimeTables.Remove(entity);
        await _db.SaveChangesAsync();

        return true;
    }
    
    public async Task<TimeTable> Update(TimeTable entity) {
        _db.TimeTables.Update(entity);
        await _db.SaveChangesAsync();

        return entity;
    }

    public async Task<TimeTable> GetByStartOfWorkDayDoctor(DateTime start) {
        return await _db.TimeTables.FirstOrDefaultAsync(x => x.StartOfWorkDayDoctor == start);
    }
    
    public async Task<TimeTable> GetByFinishOfWorkDayDoctor(DateTime finish) {
        return await _db.TimeTables.FirstOrDefaultAsync(x => x.FinishOfWorkDayDoctor == finish);
    }
    
}
