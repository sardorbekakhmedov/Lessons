namespace LogicService;

public class Calculate : ICalculate
{
    public double Sqrt(double value)
    {
        if (value < 0)
            throw new CustomException(value);
        return Math.Sqrt(value);
    }
}

