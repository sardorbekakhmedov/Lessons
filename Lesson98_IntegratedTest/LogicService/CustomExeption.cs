namespace LogicService;

internal class CustomException : Exception
{
    public CustomException(double value) 
        : base($"{value} number must not be less than zero")
    { }
}