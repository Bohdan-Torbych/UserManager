using UserManager.Core.Enumerations;

namespace UserManager.Core.Dtos.Responses;
public class UserResponse
{
    public Guid Id { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public int Age { get; set; }
    public string? Gender { get; set; }
    public DateOnly Dob { get; set; }
    public string? Token { get; set; }
}
