namespace Scrubs.DAL.Repositories;

using Domain.Entity;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

public class SpecializationRepository : ISpecializationRepository {
    
    private readonly ApplicationDbContext _db;

    public SpecializationRepository(ApplicationDbContext db) {
        _db = db;
    }

    public async Task<bool> Create(Specialization entity) {
        await _db.Specializations.AddAsync(entity);
        await _db.SaveChangesAsync();

        return true;
    }
    
    public async Task<Specialization> Get(int id) {
        return await _db.Specializations.FirstOrDefaultAsync(x => x.Id == id);
    }
    
    public async Task<List<Specialization>> Select() {
        return await _db.Specializations.ToListAsync();
    }
    
    public async Task<bool> Delete(Specialization entity) {
        _db.Specializations.Remove(entity);
        await _db.SaveChangesAsync();

        return true;
    }
    
    public async Task<Specialization> Update(Specialization entity) {
        _db.Specializations.Update(entity);
        await _db.SaveChangesAsync();

        return entity;
    }

    public async Task<Specialization> GetSpecializationByName(string name) {
        return await _db.Specializations.FirstOrDefaultAsync(x => x.Name == name);

    }
    
}
