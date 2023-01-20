using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Realstate_BL;

public class Register
{
    
    [Required]
    public string UserName { get; set; } = "";

    public string Password { set; get; } = "";

    [NotMapped]
    [Compare("Password")]
    public string ConfirmPassword { set; get; } = "";

    [Required]
    [EmailAddress]
    public string Email { get; set; } = "";
}
