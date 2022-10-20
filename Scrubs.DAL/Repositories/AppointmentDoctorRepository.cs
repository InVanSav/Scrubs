namespace Scrubs.DAL.Repositories;

using Domain.Entity;
using Interfaces;
using Microsoft.EntityFrameworkCore;

public class AppointmentDoctorRepository : IAppointmentDoctorRepository{

    private readonly ApplicationDbContext _db;

    public AppointmentDoctorRepository(ApplicationDbContext db) {
        _db = db;
    }

    public async Task<bool> Create(AppointmentDoctor entity) {
        await _db.AppointmentDoctors.AddAsync(entity);
        await _db.SaveChangesAsync();

        return true;
    }
    public Task<AppointmentDoctor> Get(int id) {
        throw new NotImplementedException();
    }

    public async Task<List<AppointmentDoctor>> Select() {
        return await _db.AppointmentDoctors.ToListAsync();
    }
    
    public async Task<bool> Delete(AppointmentDoctor entity) {
        _db.AppointmentDoctors.Remove(entity);
        await _db.SaveChangesAsync();

        return true;
    }
    public async Task<AppointmentDoctor> Update(AppointmentDoctor entity) {
        _db.AppointmentDoctors.Update(entity);
        await _db.SaveChangesAsync();

        return entity;
    }

    public async Task<AppointmentDoctor> GetByDateOfStartAppointmentWithDoctor(DateTime start) {
        return await _db.AppointmentDoctors.FirstOrDefaultAsync(x =>
            x.DateOfStartAppointmentWithDoctor == start);
    }
    
    public async Task<AppointmentDoctor> GetByDateOfFinishAppointmentWithDoctor(DateTime finish) {
        return await _db.AppointmentDoctors.FirstOrDefaultAsync(x =>
            x.DateOfFinishAppointmentWithDoctor == finish);
    }
    
    public async Task<AppointmentDoctor> GetByIdOfPatient(int id) {
        return await _db.AppointmentDoctors.FirstOrDefaultAsync(x => 
            x.IdPatient == id);
    }
    
    public async Task<AppointmentDoctor> GetByIdOfDoctor(int id) {
        return await _db.AppointmentDoctors.FirstOrDefaultAsync(x =>
            x.IdDoctor == id);
    }
    
}
