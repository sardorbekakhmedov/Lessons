using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace NugetPackageMoq.MSTest;

[TestClass]
public class CalculateSqrtTest
{
    private ICustomRandom? _iCustomRandom;
    private ICalculateSqrt? _iCalculateSqrt;
    private CalculateSqrt? _calculateSqrt;

    // [ClassInitialize]
    [TestInitialize]
    public void ClassInitialize()
    {
        var iRandom = new Mock<ICustomRandom>();
        iRandom.Setup<int>(f => f.GetRandomNumber(It.IsAny<int>())).Returns(5);
        _iCustomRandom = iRandom.Object;

        var iSqrt = new Mock<ICalculateSqrt>();
        iSqrt.Setup<float>(f => f.GetSqrt(It.IsAny<int>())).Returns(4);
        _iCalculateSqrt = iSqrt.Object;

        _calculateSqrt = new CalculateSqrt(_iCustomRandom, _iCalculateSqrt);
    }

    [DataTestMethod]
    [DataRow(5, 3)]
    [DataRow(7, 3)]
    [DataRow(8, 3)]
    public void SqrtTest(int maxLimitRandom, float expected)
    {
        // Arrange with parameters
        
        // Act 
        var result = _calculateSqrt?.GetSqrt(maxLimitRandom);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void SqrtTest2()
    {
        // Arrange
        int maxLimitRandom = 10;
        var expected = 3;
        // Act 
        var result = _calculateSqrt?.GetSqrt(maxLimitRandom);

        // Assert
        Assert.AreEqual(expected, result);
    }
}