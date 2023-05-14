using AutoFixture;

namespace Lesson_58_EntityF;

public class Program
{
    static void Main(string[] args)
    {
        var fixture = new Fixture();

        using var db = new AppDbContext();

        Console.WriteLine("Hello, Salom!");



        //var user = fixture.Create<User>();
        //user.Id = default;
        //var db = new AppDbContext();
        // db.Users.Add(user);

        //var users = db.Users.ToList();

        //foreach (var user1 in users)
        //{
        //    Console.WriteLine("User name: " + user1.UserName);
        //}

        //var person = fixture.Create<Person>();
        //person.Id = default;
        //db.Persons.Add(person);

        //db.SaveChanges();
    }
}