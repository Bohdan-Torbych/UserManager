using UserManager.Core.Enumerations;

namespace UserManager.Core.Dtos.Responses;
public class LoginResponse
{
    public Guid Id { get; set; }
    public string? Email { get; set; }
    public DateTime DateStamp { get; set; }
    public string? Status { get; set; }
}
