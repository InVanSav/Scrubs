namespace Scrubs.Service.Interfaces;

using Domain.Entity;
using Domain.Response;
using Domain.ViewModels.User;

public interface IUserService {

    Task<IBaseResponse<IEnumerable<User>>> GetUsers();

    Task<IBaseResponse<User>> Get(int id);

    Task<IBaseResponse<User>> GetByPhoneNumber(long number);

    Task<IBaseResponse<User>> GetByRole(string role);

    Task<IBaseResponse<User>> GetByPassword(string password);

    Task<IBaseResponse<bool>> GetByLoginAndPassword(string fullName, string password);

    Task<IBaseResponse<User>> GetByName(string fullName);

    Task<IBaseResponse<bool>> DeleteUser(int id);

    Task<IBaseResponse<UserViewModel>> CreateUser(UserViewModel userViewModel);

    Task<IBaseResponse<User>> Edit(int id, UserViewModel userViewModel);

}
