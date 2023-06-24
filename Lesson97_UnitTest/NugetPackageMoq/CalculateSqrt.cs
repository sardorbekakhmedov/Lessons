namespace NugetPackageMoq;

public class CalculateSqrt
{
    private readonly ICalculateSqrt _calculateSqrt;

    private readonly ICustomRandom _customRandom;
    public CalculateSqrt(ICustomRandom iCustomRandom, ICalculateSqrt iCalculateSqrt)
    {
        _calculateSqrt = iCalculateSqrt;
        _customRandom = iCustomRandom;
    }


    public float GetSqrt(int maxNumber)
    {
        var randomNumber = _customRandom.GetRandomNumber(maxNumber);
        var sqrt = _calculateSqrt.GetSqrt(randomNumber);
        var resultNumber = sqrt + randomNumber;

        return (float)Math.Sqrt(resultNumber);
    }

}
 