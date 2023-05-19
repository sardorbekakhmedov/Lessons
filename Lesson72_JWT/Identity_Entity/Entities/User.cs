using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Identity_Data.Entities;


public class User
{
    public Guid Id { get; set; }

    [Column("firstname")]
    public string? FirstName { get; set; }
    public string? Email { get; set; }

    public required string Password { get; set; }
    [Compare(nameof(Password))]
    public required string ConfirmPassword { get; set; }
    public required string UserName { get; set; }
}