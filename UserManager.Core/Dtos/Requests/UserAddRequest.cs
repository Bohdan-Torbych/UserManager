using UserManager.Core.Enumerations;

namespace UserManager.Core.Dtos.Requests;
public class UserAddRequest
{
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Gender { get; set; }
    public DateOnly Dob { get; set; }
}
