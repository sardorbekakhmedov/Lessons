using Lesson74Data.Entities;

namespace Lesson74Data.Interfaces;

public interface ISmallestMultipleFinder
{
    int FindSmallestMultiple(int number);
    
    int GetLeastCommonMultiple(int num1, int num2);
}