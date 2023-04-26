using Lesson54_EF.DataDb;
using Lesson54_EF.One_To_One.Models;

Console.Clear();

var address = new Address
{
    City = "Farg'ona",
    District = "Eski shahar",
    Region = "Far",
    Village = "Tolachi"
};


var person = new Person
{
    FirstName = "Vali",
    LastName = "Aliyev",
    Age = 31,
    Address = address
};

var db = new AppDbContext();

db.Add(person);
db.SaveChanges();


Console.WriteLine("Tamom - Tamom");