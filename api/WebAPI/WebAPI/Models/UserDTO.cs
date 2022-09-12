using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models;

public class UserDTO
{
    [Required(ErrorMessage = "Email address is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Password is required")]
    [MinLength(6, ErrorMessage = "Minimal password length: 6")]
    public string Password { get; set; }
}