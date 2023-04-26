using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Data.Models;

[Table("users")]
public class User
{
    [Key]
    [Column("id")]

    public int Id { get; set; }
    [Required]
    [RegularExpression("[A-Za-z]")]
    [MaxLength(50)]
    [MinLength(2)]
    public string Name { get; set; } = string.Empty;

    [Column("is_active")]
    public bool IsActive { get; set; } = true;
}