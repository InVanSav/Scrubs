namespace Scrubs.DAL.Repositories;

using Domain.Entity;
using Interfaces;
using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository {

    private readonly ApplicationDbContext _db;

    public UserRepository(ApplicationDbContext db) {
        _db = db;
    }
    
    public async Task<bool> Create(User entity) {
        if (_db.Users != null) await _db.Users.AddAsync(entity);
        await _db.SaveChangesAsync();

        return true;
    }
    
    public async Task<User> Get(int id) {
        return await _db.Users.FirstOrDefaultAsync(x => x.Id == id);
    }
    
    public async Task<List<User>> Select() {
        return await _db.Users.ToListAsync();
    }
    
    public async Task<bool> Delete(User entity) {
        _db.Users.Remove(entity);
        await _db.SaveChangesAsync();

        return true;
    }
    
    public async Task<User> Update(User entity) {
        _db.Users.Update(entity);
        await _db.SaveChangesAsync();

        return entity;
    }

    public async Task<User> GetByFullName(string fullName) {
        return await _db.Users.FirstOrDefaultAsync(x => x.FullName == fullName);
    }
    
    public async Task<User> GetByPhoneNumber(long phoneNumber) {
        return await _db.Users.FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber);
    }
    
    public async Task<User> GetByRole(string role) {
        return await _db.Users.FirstOrDefaultAsync(x => x.Role == role);
    }
    
    public async Task<User> GetByPassword(string password) {
        return await _db.Users.FirstOrDefaultAsync(x => x.Password == password);
    }
    
    public async Task<bool> GetByLoginAndPassword(string fullName, string password) { 
        var fullNameUser = await _db.Users.FirstOrDefaultAsync(x => x.FullName == fullName);
        var passwordUser = await _db.Users.FirstOrDefaultAsync(x => x.Password == password);

        return fullNameUser == null && passwordUser == null;
    }

}
