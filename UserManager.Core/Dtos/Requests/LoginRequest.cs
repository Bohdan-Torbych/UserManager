using System.ComponentModel.DataAnnotations;

namespace UserManager.Core.Dtos.Requests;
public class LoginRequest
{
    [Required(ErrorMessage = "{0} cannot be blank")]
    [EmailAddress(ErrorMessage = "{0} is not valid email address format")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "{0} cannot be blank")]
    public string? Password { get; set; }
}
