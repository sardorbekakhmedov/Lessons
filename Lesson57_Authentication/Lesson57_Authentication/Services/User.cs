using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lesson57_Authentication.Services;

public class User
{
    public string Id { get; set; }

    [Display]
    [Required(ErrorMessage = "Ismni kiritish majubiy")]
    public string? Name { get; set; }
    public int Age { get; set; }
}