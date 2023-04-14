using UserManager.Core.Enumerations;

namespace UserManager.Core.Entities;
public class Login
{
    public Guid Id { get; set; }
    public string? Email { get; set; }
    public DateTime DateStamp {get; set; }
    public Status Status { get; set; }
}
