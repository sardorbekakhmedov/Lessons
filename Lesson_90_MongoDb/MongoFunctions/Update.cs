using MongoDB.Driver;

namespace Lesson90_MongoDb.MongoFunctions;

public class Update
{
    public static async Task UpdateAsync(IMongoCollection<Company>? companies)
    {
        if (companies is not null)
        {
            var filter = Builders<Company>.Filter.Eq(company => company.Name, "PaypoqPrint");

            var company = await companies.Find(filter).FirstOrDefaultAsync();

            if (company is not null)
            {
                company.Name = "Zo'r";

                await companies.ReplaceOneAsync(filter, company);
            }
        }
    }
}