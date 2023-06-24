using Lesson96_Tests;
using System.Diagnostics;

namespace Lesson96.xUnitTests;

public class CalculatorXUnitTests : IDisposable
{
    private Calculator? _calculator;
    public CalculatorXUnitTests()
    {
        Debug.WriteLine("XUnit Constructor xUnit is working!");
        _calculator = new Calculator();
    }

    // [Fact(Skip = "This method not working")]
    // [Trait("Category1", "ThrowsException")]
    //[Trait("Category", "Valid")]
    [Fact]
    public void Sum_13_and_27_return_40()
    {
        Debug.WriteLine("XUnit Method Sum_13_and_28_return_40 is working!");
        // Arrange
        var num1 = 13;
        var num2 = 27;
        var expected = num1 + num2;

        // Act
        var actual = _calculator?.SumTwoNumbers(num1, num2);
        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(10, 5, 50)]
    [InlineData(3,7,21)]
    [InlineData(1,1,1)]
    [InlineData(2,9,18)]
    public void MultiplyTestMethodWithParam(int x, int y, int expected)
    {
        Debug.WriteLine("XUnit Method MultiplyTestMethodWithParam is working!");

        // Act
        var actual = _calculator?.MultiplyTwoNumbers(x, y);

        // Assert
        Assert.Equal(expected, actual);
    }

    // 1 - usul 
    #region Theory MemberData nameof()  1 - usul
    public static TheoryData<int, int, int> CalculateTwoNumber(int x, int y, int expected)
    {
        return new TheoryData<int, int, int>
        {
            {3, 5,  15},
            {4, 8,  32},
            {7, 10, 70},
            {6, 9,  54}
        };
    }

    [Theory]
    [MemberData(nameof(CalculateTwoNumber))]
    public void MultiplyTestMethodWithParam2(int x, int y, int expected)
    {
        Debug.WriteLine("XUnit Method MultiplyTestMethodWithParam is working!");

        // Act
        var actual = _calculator?.MultiplyTwoNumbers(x, y);

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion


    // 2 - usul 
    #region Theory ClassData typeof()  2 - usul
    public class CalculateNumbersClass : TheoryData<int, int, int>
    {
        public CalculateNumbersClass()
        {
            Add(4, 2, 8);
            Add(9, 5, 45);
            Add(6, 7, 42);
            Add(3, 1, 3);
        }
    }

    [Theory]
    [ClassData(typeof(CalculateNumbersClass))]
    public void MultiplyTestMethodWithParam3(int x, int y, int expected)
    {
        Debug.WriteLine("XUnit Method MultiplyTestMethodWithParam is working!");

        // Act
        var actual = _calculator?.MultiplyTwoNumbers(x, y);

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion

    public void Dispose()
    {
       //  _calculator = null;
    }
}