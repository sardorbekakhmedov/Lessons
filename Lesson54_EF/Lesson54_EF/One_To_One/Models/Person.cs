using System.ComponentModel.DataAnnotations.Schema;
namespace Lesson54_EF.One_To_One.Models;

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public int AddressId { get; set; }
    public virtual Address Address { get; set; }
}