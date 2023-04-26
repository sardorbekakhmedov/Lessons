namespace EFCore.Data.Models;

public class UserPassport
{

    public int Id { get; set; }
    public int UserId { get; set; }
    public string? Serial { get; set; }
    public string? SerialNumber { get; set; }
    public string? Pnfl { get; set; }
    public string? Tin { get; set; }
}