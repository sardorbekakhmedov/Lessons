using Lesson74Data.Interfaces;

namespace Lesson74Data.RepositoryServices;

public class SmallestMultipleFinder : ISmallestMultipleFinder
{
    public int FindSmallestMultiple(int n)
    {
        int smallestMultiple = 1;

        for (int i = 2; i <= n; i++)
        {
            smallestMultiple = GetLeastCommonMultiple(smallestMultiple, i);
        }

        return smallestMultiple;
    }

    public int GetLeastCommonMultiple(int a, int b)
    {
        int originalA = a;
        int originalB = b;

        while (a != b)
        {
            if (a < b)
                a += originalA;
            else
                b += originalB;
        }

        return a;
    }

}