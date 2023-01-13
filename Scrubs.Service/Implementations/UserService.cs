namespace Scrubs.Service.Implementations;

using DAL.Interfaces;
using Domain.Entity;
using Domain.Enum;
using Domain.Response;
using Interfaces;

public class UserService : IUserService {

    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository) {
        _userRepository = userRepository;
    }

    public async Task<IBaseResponse<User>> Get(int id) {

        var baseResponse = new BaseResponse<User>();

        try {

            var user = await _userRepository.Get(id);

            if (user == null) {
                baseResponse.Result = "User not found:(";
                baseResponse.StatusCode = StatusCode.DataNotFound;
                return baseResponse;
            }

            baseResponse.Data = user;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;

        } catch (Exception ex) {

            return new BaseResponse<User>() {
                Result = $"[Get] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };

        }

    }

    public async Task<IBaseResponse<User>> GetByPhoneNumber(long number) {

        var baseResponse = new BaseResponse<User>();

        try {

            var user = await _userRepository.GetByPhoneNumber(number);

            if (user == null) {
                baseResponse.Result = "User not found:(";
                baseResponse.StatusCode = StatusCode.DataNotFound;
                return baseResponse;
            }

            baseResponse.Data = user;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;

        } catch (Exception ex) {

            return new BaseResponse<User>() {
                Result = $"[GetByPhoneNumber] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };

        }

    }

    public async Task<IBaseResponse<User>> GetByRole(string role) {

        var baseResponse = new BaseResponse<User>();

        try {

            var user = await _userRepository.GetByRole(role);

            if (user == null) {
                baseResponse.Result = "User not found:(";
                baseResponse.StatusCode = StatusCode.DataNotFound;
                return baseResponse;
            }

            baseResponse.Data = user;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;

        } catch (Exception ex) {

            return new BaseResponse<User>() {
                Result = $"[GetByRole] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };

        }

    }

    public async Task<IBaseResponse<User>> GetByPassword(string password) {

        var baseResponse = new BaseResponse<User>();

        try {

            var user = await _userRepository.GetByPassword(password);

            if (user == null) {
                baseResponse.Result = "User not found:(";
                baseResponse.StatusCode = StatusCode.DataNotFound;
                return baseResponse;
            }

            baseResponse.Data = user;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;

        } catch (Exception ex) {

            return new BaseResponse<User>() {
                Result = $"[GetByPassword] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };

        }

    }

    public async Task<IBaseResponse<bool>> GetByLoginAndPassword(string fullName, string password) {

        var baseResponse = new BaseResponse<bool>();

        try {

            var user = await _userRepository.GetByLoginAndPassword(fullName, password);

            if (!user) {
                baseResponse.Result = "User not found:(";
                baseResponse.StatusCode = StatusCode.DataNotFound;
                return baseResponse;
            }

            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;

        } catch (Exception ex) {

            return new BaseResponse<bool>() {
                Result = $"[GetByLoginAndPassword] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };

        }

    }

    public async Task<IBaseResponse<User>> GetByName(string fullName) {

        var baseResponse = new BaseResponse<User>();

        try {

            var user = await _userRepository.GetByFullName(fullName);

            if (user == null) {
                baseResponse.Result = "User not found:(";
                baseResponse.StatusCode = StatusCode.DataNotFound;
                return baseResponse;
            }

            baseResponse.Data = user;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;

        } catch (Exception ex) {

            return new BaseResponse<User>() {
                Result = $"[GetByName] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };

        }

    }

    public async Task<IBaseResponse<IEnumerable<User>>> GetUsers() {

        var baseResponse = new BaseResponse<IEnumerable<User>>();

        try {

            var users = await _userRepository.Select();

            if (users.Count == 0) {
                baseResponse.Result = "Users not found:(";
                baseResponse.StatusCode = StatusCode.DataNotFound;
                return baseResponse;
            }

            baseResponse.Data = users;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;

        } catch (Exception ex) {

            return new BaseResponse<IEnumerable<User>>() {
                Result = $"[GetUsers] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };

        }

    }

    public async Task<IBaseResponse<bool>> DeleteUser(int id) {

        var baseResponse = new BaseResponse<bool>();

        try {

            var user = await _userRepository.Get(id);

            if (user == null) {
                baseResponse.Result = "User not found:(";
                baseResponse.StatusCode = StatusCode.DataNotFound;
                return baseResponse;
            }

            await _userRepository.Delete(user);
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;

        } catch (Exception ex) {

            return new BaseResponse<bool>() {
                Result = $"[DeleteUser] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };

        }

    }

    public async Task<IBaseResponse<User>> CreateUser(User user) {

        var baseResponse = new BaseResponse<User>();

        try {

            var usere = new User() {
                PhoneNumber = user.PhoneNumber,
                FullName = user.FullName,
                Role = user.Role,
                Password = user.Password,
            };

            if (usere == null) {
                baseResponse.Result = "User wasn't create:(";
                baseResponse.StatusCode = StatusCode.DataWasNotAdded;
                return baseResponse;
            }

            await _userRepository.Create(usere);
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;

        } catch (Exception ex) {

            return new BaseResponse<User>() {
                Result = $"[CreateUser] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };

        }

    }
    public async Task<IBaseResponse<User>> Edit(int id, User user) {

        var baseResponse = new BaseResponse<User>();

        try {

            var usere = _userRepository.Get(id);

            if (user == null) {
                baseResponse.StatusCode = StatusCode.DataNotFound;
                baseResponse.Result = "User not found:(";
                return baseResponse;
            }

            usere.Result.Id = user.Id;
            usere.Result.Password = user.Password;
            usere.Result.FullName = user.FullName;
            usere.Result.PhoneNumber = user.PhoneNumber;
            usere.Result.Role = user.Role;

            await _userRepository.Update(await usere);

            return baseResponse;

        } catch (Exception ex) {

            return new BaseResponse<User>() {
                Result = $"[Edit] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError,
            };

        }

    }

}
