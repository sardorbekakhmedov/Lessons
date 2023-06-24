using MongoDB.Bson.Serialization.Attributes;

public class Company
{
    [BsonId]
    public Guid CompoanyId {get; set;} = Guid.NewGuid();
    public string Name { get; set; } = null!;
    public string Address { get; set; }= null!;
    public List<Employee> Employees { get; set; }

    public Company()
    {
        Employees = new List<Employee>();
    }
}
