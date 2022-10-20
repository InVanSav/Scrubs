namespace Scrubs.DAL.Repositories;

using Domain.Entity;
using Interfaces;
using Microsoft.EntityFrameworkCore;

public class DoctorRepository : IDoctorRepository {
    
    private readonly ApplicationDbContext _db;

    public DoctorRepository(ApplicationDbContext db) {
        _db = db;
    }

    public async Task<bool> Create(Doctor entity) {
        await _db.Doctors.AddAsync(entity);
        await _db.SaveChangesAsync();

        return true;
    }
    
    public async Task<Doctor> Get(int id) {
        return await _db.Doctors.FirstOrDefaultAsync(x => x.Id == id);
    }
    
    public async Task<List<Doctor>> Select() {
        return await _db.Doctors.ToListAsync();
    }
    
    public async Task<bool> Delete(Doctor entity) {
        _db.Doctors.Remove(entity);
        await _db.SaveChangesAsync();

        return true;
    }
    
    public async Task<Doctor> Update(Doctor entity) {
        _db.Doctors.Update(entity);
        await _db.SaveChangesAsync();

        return entity;
    }

    public async Task<Doctor> GetDoctorByFullName(string fullName) {
        return await _db.Doctors.FirstOrDefaultAsync(x => x.FullName == fullName);
    }
    
    public async Task<Doctor> GetDoctorByJobTitle(string jobTitle) {
        return await _db.Doctors.FirstOrDefaultAsync(x => x.JobTitle == jobTitle);
    }
    
}
