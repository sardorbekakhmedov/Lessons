using ConsoleCustomMocking;

var instance = Mock.CreateMockObject<IPriceService>();

var result = instance.CalculatePrice();

Console.WriteLine($"Price: {result}");


public interface IPriceService
{
    int CalculatePrice();
}
