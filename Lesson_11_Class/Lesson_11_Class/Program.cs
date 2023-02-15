 
var user = new User();

user.Name = "Test";
user.Age = 1;


user.Update("salom", 9);

Console.WriteLine(user.Name);
Console.WriteLine(user.Age);



class User
{
    public string Name;
    public int Age;

    public void Update(string name)
    {
        this.Name = name;
    }
    public void Update(string name, int age = 0)
    {
        this.Name = name;
        this.Age = age;
    }
}