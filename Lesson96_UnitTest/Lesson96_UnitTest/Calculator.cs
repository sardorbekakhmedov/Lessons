namespace Lesson96_Tests;

public class Calculator
{
    public int SumTwoNumbers(int x, int y)
    {
        if (x < 0 || y < 0)
            throw new NegativeNumberException(x, y);

        return x + y;
    }

    public int MultiplyTwoNumbers(int x, int y)
    {
        if (x < 0 || y < 0)
            throw new NegativeNumberException(x, y);

        return x * y;
    }
    
}


public class NegativeNumberException : Exception
{
    public NegativeNumberException(int x, int y) 
        : base($"The entered number must not be negative x: {x} y: {y}") 
    { }
}