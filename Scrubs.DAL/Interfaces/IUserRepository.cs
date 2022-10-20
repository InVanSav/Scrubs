namespace Scrubs.DAL.Interfaces;

using Domain.Entity;

public interface IUserRepository : IBaseRepository<User> {

    Task<User> GetByFullName(string fullName);

    Task<User> GetByPhoneNumber(long phoneNumber);

    Task<User> GetByRole(string role);

    Task<User> GetByPassword(string password);

    Task<bool> GetByLoginAndPassword(string fullName, string password);

}
