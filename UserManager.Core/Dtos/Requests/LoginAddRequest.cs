using UserManager.Core.Enumerations;

namespace UserManager.Core.Dtos.Requests;

public class LoginAddRequest
{
    public string? Email { get; set; }
    public DateTime DateStamp { get; set; }
    public Status Status { get; set; }
}