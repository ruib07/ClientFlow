using Microsoft.AspNetCore.Identity;

namespace ClientFlow.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}
