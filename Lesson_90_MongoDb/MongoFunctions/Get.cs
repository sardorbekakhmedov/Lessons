using MongoDB.Driver;

namespace Lesson90_MongoDb.MongoFunctions;

public class Get
{
    public static async Task GetAsync(IMongoCollection<Company> companies)
    {
        Company company = await companies.Find(n => n.Name == "PaypoqPrint").FirstOrDefaultAsync();
        Console.WriteLine(company.Name);

        company = await companies
            .Find(n => n.Name == "PaypoqPrint" && n.Address == "Tapichka ko'chasi, Ishton mahalla")
            .FirstOrDefaultAsync();
        Console.WriteLine(company);

        var filter1 = Builders<Company>.Filter.Eq(n => n.Address, "Tapichka ko'chasi, Ishton mahalla");
        company = await companies.Find(filter1).FirstOrDefaultAsync();
        Console.WriteLine(company.Name);

        var filterGt = Builders<Company>.Filter.Gt(n => n.Name, "PaypoqPrint");
        var filterLt = Builders<Company>.Filter.Lt(n => n.Name, "PaypoqPrint");

        company = await companies.Find(filterGt).FirstOrDefaultAsync();
        company = await companies.Find(filterLt).FirstOrDefaultAsync();

        List<Company> newCompanies = await companies.Find(c => true).ToListAsync();
    }
}