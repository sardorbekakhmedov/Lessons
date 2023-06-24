using System.Diagnostics;
using Lesson96_Tests;

namespace Lesson96.NUnitTests;

[TestFixture]
public class CalculatorNUnitTest
{
    private Calculator? _calculator;

    [SetUp]
    public void Setup()
    {
        Debug.WriteLine("NUnit Setup is working!");
        _calculator = new Calculator();
    }


    [Test]  // Methodni test methodi sifatida tanish uchun
    //[Category("Valid")] // Categoryga nom berish
    //[Retry(4)] // Test da xato chiqsa qayta qayta 4 marta ishlatishga urinadi
    //[Timeout(1000)]  // Agar berilgan vaqt ichida test to'g'ri bajarilmasa zatolik qaytadi
    //[Order(2)]  // Agarda methodlar bir nechta bo'ladingan bo'lsa, Nechanchi bo'lib ichga tushishini ko'rasatish
   // [Category("ThrowsException")]
    public void Sum_10_and_15_return_25()
    {
        Debug.WriteLine("NUnit Method Sum_10_and_15_return_25 is working!");
        // Arrange
        var num1 = 10;
        var num2 = 15;
        var expected = num1 + num2;

        // Act
        var actual = _calculator!.SumTwoNumbers(num1, num2);
        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestCase(3,3,9)]
    [TestCase(4,5,20)]
    [TestCase(6,6,36)]
    [TestCase(9,9,81)]
   public void MultiplyTestMethodWithParam(int x, int y, int expected)
   {
       Debug.WriteLine("NUnit Method MultiplyTestMethodWithParam is working!");

       // Act
       var actual = _calculator?.MultiplyTwoNumbers(x, y);

       // Assert
       Assert.AreEqual(expected, actual);
   }
}