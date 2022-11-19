namespace Scrubs.Tests.User;

using DAL.Interfaces;
using Domain.ViewModels.User;
using Service.Implementations;

public class UserTests {
    
    private readonly UserService _userService;

    public UserTests() {
        var userRepositoryMock = new Mock<IUserRepository>();
        _userService = new UserService(userRepositoryMock.Object);
    }

    [Fact] 
    public void GetUserOrNo_ShouldWork() {

        var res = _userService.Get(0);

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void GetUserByPhoneNumberOrNo_ShouldWork() {

        var res = _userService.GetByPhoneNumber(89132901830);

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void GetUserByPhoneNumberOrNo_ShouldFail() {

        var res = _userService.GetByPhoneNumber(8912901830);

        Assert.True(res.IsFaulted);
        Assert.Equal("User not found :(", res.Result.Result);
        Assert.Equal(0, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void GetUserByRoleOrNo_ShouldWork() {

        var res = _userService.GetByRole("Admin");

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void GetUserByPasswordOrNo_ShouldWork() {

        var res = _userService.GetByPassword("hello1234");

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void GetUserByLoginAndPasswordOrNo_ShouldWork() {

        var res = _userService.GetByLoginAndPassword(
        "Ivan_Savickij",
        "hello1234"
        );

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void GetUserByNameOrNo_ShouldWork() {

        var res = _userService.GetByName("Ivan_Savickij");

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void GetUsersOrNo_ShouldWork() {

        var res = _userService.GetUsers();

        Assert.True(res.IsCompleted);
        Assert.Equal(500, (int)res.Result.StatusCode);

    }
    
    
    [Fact] 
    public void DeleteUserOrNo_ShouldWork() {

        var res = _userService.DeleteUser(0);

        Assert.True(res.IsCompleted);
        Assert.Equal(0, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void CreateUserOrNo_ShouldWork() {

        var user = new UserViewModel() {
            Id = 0,
            FullName = "Ivan_Savickij",
            Password = "hello1234",
            PhoneNumber = 89132901830,
            Role = "Admin"
        };

        var res = _userService.CreateUser(user);

        Assert.True(res.IsCompleted);
        Assert.Equal(200, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void EditUserOrNo_ShouldWork() {
        
        var user = new UserViewModel() {
            Id = 2,
            FullName = "John_Savickij",
            Password = "hello1234",
            PhoneNumber = 89132901830,
            Role = "Admin"
        };

        var res = _userService.Edit(0, user);

        Assert.True(res.IsCompleted);
        Assert.Equal(500, (int)res.Result.StatusCode);

    }
    
}
