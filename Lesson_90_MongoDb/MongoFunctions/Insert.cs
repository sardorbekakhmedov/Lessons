using MongoDB.Driver;

namespace Lesson90_MongoDb.MongoFunctions;

public class InsertDataCompany
{
    public static void InsertCompany(IMongoCollection<Company> companies)
    {
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

        companies.InsertOne(company);
    }
}