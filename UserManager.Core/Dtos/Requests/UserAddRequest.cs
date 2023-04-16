using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using UserManager.Core.Enumerations;

namespace UserManager.Core.Dtos.Requests;
public class UserAddRequest
{
    [Required(ErrorMessage = "{0} cannot be empty")]
    [DisplayName("Full Name")]
    public string? FullName { get; set; }

    [Required(ErrorMessage = "{0} cannot be empty")]
    [EmailAddress(ErrorMessage = "{0} is not valid email address")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "{0} cannot be empty")]
    [MinLength(6, ErrorMessage = "{0} must contain at least {1} characters")]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*\d).+$", ErrorMessage = "{0} must contain at least one uppercase letter and one digit")]
    public string? Password { get; set; }

    [Required(ErrorMessage = "{0} cannot be empty")]
    public string? Gender { get; set; }

    [Required(ErrorMessage = "{0} cannot be empty")]
    [DisplayName("Date of birth")]
    public DateOnly Dob { get; set; }
}
