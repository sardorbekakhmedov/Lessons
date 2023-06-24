
public class Employee
{
    public Guid EmployeeId { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = null!;
    public string Position { get; set; } = null!;
}
