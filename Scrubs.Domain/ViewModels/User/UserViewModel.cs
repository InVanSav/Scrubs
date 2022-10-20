namespace Scrubs.Domain.ViewModels.User; 

public class UserViewModel {
    
    public int Id { get; set; }
    
    public long PhoneNumber { get; set; }

    public string FullName { get; set; } = string.Empty;

    public string Role { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
    
}
