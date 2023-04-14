using Microsoft.AspNetCore.Identity;
using System.Security.Principal;
using UserManager.Core.Enumerations;

namespace UserManager.Core.Entities;

public class AppUser : IdentityUser<Guid>
{
    public string? FullName { get; set; }
    public Gender Gender { get; set; }
    public DateOnly Dob { get; set; }
    public string? Token { get; set; }
}
