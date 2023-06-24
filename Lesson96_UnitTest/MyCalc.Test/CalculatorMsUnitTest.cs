
/*
 MSUnitTest
	AssemblyInitialize

	TestClass1
		TestInitialize
		    TestMethod
		TestCleanUp

		TestInitialize
		    TestMethod2
		TestCleanUp

		TestInitialize
		    TestMethod3
		TestCleanUp

	TestClass2
		ClassInitialize
		    TestMethod
		    TestMethod2
		    TestMethod3
		ClassCleanUp

	AssemblyCleanUp
 */

using System.Diagnostics;
using Lesson96_Tests;

namespace Lesson96.MsTests;


[TestClass]
public class CalculatorMsUnitTest
{
    private Calculator? _calculator;

    [TestInitialize]
    public void MsTestInitialize()
    {
        Debug.WriteLine("MSUnit TestInitialize is working!");
        _calculator = new Calculator();
    }

    [TestMethod]
    //[Ignore("This test method is ignored")]
    [TestCategory("ThrowsException")]

    public void Sum_10_and_20_return_30()
    {
        Debug.WriteLine("MSUnit Method Sum_10_and_20_return_30 is working!");

        // Arrange
        var num1 = 10; 
        var num2 = 20;
        var expected = num1 + num2;

        // Act
        var actual = _calculator?.SumTwoNumbers(num1, num2);

        // Assert
        Assert.AreEqual(expected, actual);

        // Assert.AreNotEqual(actual, 0);
        // Assert.IsTrue(actual > 0);
        // Assert.IsFalse(actual < 100);
    }

    [DataTestMethod]
    [DataRow(2,2,4)]
    [DataRow(7,7,49)]
    [DataRow(3,3,9)]
    public void MultiplyTestMethodWithParam(int x, int y, int expected)
    {
        Debug.WriteLine("MSUnit  Method MultiplyTestMethodWithParam is working!");

        // Act
        var actual = _calculator?.MultiplyTwoNumbers(x, y);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestCleanup]
    public void Cleanup()
    {
        Debug.WriteLine("TestCleanup is working!");
        _calculator = null;
    }
}