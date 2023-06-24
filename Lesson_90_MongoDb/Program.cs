using MongoDB.Driver;

var connectionMongoDb = @"mongodb://mongodb_username:mongodb_password@localhost:27017";

var client  = new MongoClient(connectionMongoDb);

var dbCompany = client.GetDatabase("company");  // CREATE DATABASE
var tableCompanies = dbCompany.GetCollection<Company>("companies");  // CREATE TABLE

var company = new Company
{
    Name = "PaypoqPrint11",
    Address = "Tapichka ko'chasi, Ishton mahalla11",
    Employees = new List<Employee>()
    {
        new Employee
        {
            Name = "Toshturdi11",
            Position = "Paypoqfurush11",
        },

        new Employee
        {
            Name = "Teshavoy11",
            Position = "Qorovul11",
        },

        new Employee
        {
            Name = "Jonibek11",
            Position = "Yuk tashuvchi11",
        }
    }
};

tableCompanies.InsertOne(company);


var comp = await tableCompanies.Find(user => user.Name == "PaypoqPrint").FirstOrDefaultAsync();

Console.WriteLine(comp.Address);
Console.WriteLine("==========================================================");

var companies = await tableCompanies.Find(t => true).ToListAsync();

foreach (var item in companies)
{
    Console.WriteLine(item.Name);
}

Console.WriteLine("Ok");