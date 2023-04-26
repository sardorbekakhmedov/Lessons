namespace ConsoleApp1;

public class User
{
    public int Id;
    string Name { get; set; }
    public int Age { get; set; }

    protected  void Set(int id)
    {
        Id = id;
    }
}