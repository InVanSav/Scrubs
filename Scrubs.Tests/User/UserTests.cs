namespace Scrubs.Tests.User;

using Domain.ViewModels.User;
using Service.Implementations;

public class UserTests {

    private readonly UserService _userService;

    public UserTests(UserService userService) {
        _userService = userService;
    }

    [Fact] 
    public void GetUserOrNo_ShouldFail() {

        var res = _userService.Get(0);

        Assert.True(res.IsFaulted);
        Assert.Equal("User not found:(", res.Result.Result);
        Assert.Equal(0, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void GetUserByPhoneNumberOrNo_ShouldFail() {

        var res = _userService.GetByPhoneNumber(89132901830);

        Assert.True(res.IsFaulted);
        Assert.Equal("User not found:(", res.Result.Result);
        Assert.Equal(0, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void GetUserByRoleOrNo_ShouldFail() {

        var res = _userService.GetByRole("Admin");

        Assert.True(res.IsFaulted);
        Assert.Equal("User not found:(", res.Result.Result);
        Assert.Equal(0, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void GetUserByPasswordOrNo_ShouldFail() {

        var res = _userService.GetByPassword("hello1234");

        Assert.True(res.IsFaulted);
        Assert.Equal("User not found:(", res.Result.Result);
        Assert.Equal(0, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void GetUserByLoginAndPasswordOrNo_ShouldFail() {

        var res = _userService.GetByLoginAndPassword(
        "Ivan Savickij",
        "hello1234"
        );

        Assert.True(res.IsFaulted);
        Assert.Equal("User not found:(", res.Result.Result);
        Assert.Equal(0, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void GetUserByNameOrNo_ShouldFail() {

        var res = _userService.GetByName("Ivan Savickij");

        Assert.True(res.IsFaulted);
        Assert.Equal("User not found:(", res.Result.Result);
        Assert.Equal(0, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void GetUsersOrNo_ShouldFail() {

        var res = _userService.GetUsers();

        Assert.True(res.IsFaulted);
        Assert.Equal("Users not found:(", res.Result.Result);
        Assert.Equal(0, (int)res.Result.StatusCode);

    }
    
    
    [Fact] 
    public void DeleteUserOrNo_ShouldFail() {

        var res = _userService.DeleteUser(0);

        Assert.True(res.IsFaulted);
        Assert.Equal("User not found:(", res.Result.Result);
        Assert.Equal(0, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void CreateUserOrNo_ShouldFail() {

        var user = new UserViewModel() {
            Id = 0,
            FullName = "Ivan Savickij",
            Password = "hello1234",
            PhoneNumber = 89132901830,
            Role = "Admin"
        };

        var res = _userService.CreateUser(user);

        Assert.True(res.IsFaulted);
        Assert.Equal("User wasn't create:(", res.Result.Result);
        Assert.Equal(1, (int)res.Result.StatusCode);

    }
    
    [Fact] 
    public void EditUserOrNo_ShouldFail() {
        
        var user = new UserViewModel() {
            Id = 0,
            FullName = "Ivan Savickij",
            Password = "hello1234",
            PhoneNumber = 89132901830,
            Role = "Admin"
        };

        var res = _userService.Edit(0, user);

        Assert.True(res.IsFaulted);
        Assert.Equal("User not found:(", res.Result.Result);
        Assert.Equal(0, (int)res.Result.StatusCode);

    }
    
}
