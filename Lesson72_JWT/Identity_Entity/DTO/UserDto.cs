using System.ComponentModel.DataAnnotations;

namespace Identity_Data.DTO;

public class UserDto
{
    public string? FirstName { get; set; }
    public string? Email { get; set; }
    public required string Password { get; set; }

    [Compare(nameof(Password))]
    public required string ConfirmPassword { get; set; }
    public required string UserName { get; set; }

}