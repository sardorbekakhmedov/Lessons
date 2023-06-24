using Moq;
using NugetPackageMoq;
using Range = Moq.Range;

var iCustomRandom = new Mock<ICustomRandom>();
iCustomRandom.Setup(f => f.GetRandomNumber(It.IsAny<int>())).Returns(5);
iCustomRandom.Setup(f => f.GetRandomNumber(It.IsIn<int>(1,2,3,4,5,6) )).Returns(3);
iCustomRandom.Setup(f => f.GetRandomNumber(It.IsNotIn<int>(11,22,3,44,5,69) )).Returns(5);
iCustomRandom.Setup(f => f.GetRandomNumber(It.IsInRange<int>(15,30, Range.Exclusive) )).Returns(5);
iCustomRandom.Setup(f => f.GetRandomNumber(It.IsInRange<int>(10, 20, Range.Inclusive) )).Returns(4);

ICustomRandom objCustomRandom = iCustomRandom.Object;


var iCalculateSqrt = new Mock<ICalculateSqrt>();
iCalculateSqrt.Setup(f => f.GetSqrt(It.IsAny<int>())).Returns(4);
ICalculateSqrt objCalculateSqrt = iCalculateSqrt.Object;

var calculate = new CalculateSqrt(objCustomRandom, objCalculateSqrt);

var result1 = calculate.GetSqrt(15);
Console.WriteLine(result1);

var result2= calculate.GetSqrt(23);
Console.WriteLine(result2);
