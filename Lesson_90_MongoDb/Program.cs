using MongoDB.Driver;

var connectionMongoDb = @"mongodb://mongodb_username:mongodb_password@localhost:27017";

var client  = new MongoClient(connectionMongoDb);

var dbCompany = client.GetDatabase("company");  // CREATE DATABASE
IMongoCollection<Company> tableCompanies = dbCompany.GetCollection<Company>("companies");  // CREATE TABLE







Console.WriteLine("==========================================================");

var companies = await tableCompanies.Find(t => true).ToListAsync();

foreach (var item in companies)
{
    Console.WriteLine(item.Name);
}

Console.WriteLine("Ok");