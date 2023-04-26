namespace Lesson54_EF.One_To_One.Models;

public class Address
{
    public int Id { get; set; }
    public string Region { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public string Village { get; set; }
}