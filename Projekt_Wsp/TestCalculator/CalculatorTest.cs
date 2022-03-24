using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCalculator
{
    [TestClass]
    public class CalculatorTest
    {
       private Calculator.Calculator calc;

       [TestInitialize]
        public void Initialize()
        {
            calc = new Calculator.Calculator();
        }

        [TestMethod]
        public void AddTest()
        {
            Assert.AreEqual(calc.AddNumbers(5, 6), 11);
            Assert.AreEqual(calc.AddNumbers(-1, 1), 0);
            Assert.AreEqual(calc.AddNumbers(0.000001, 1), 1.000001);
            Assert.AreEqual(calc.AddNumbers(44444444, 22222222), 66666666);

        }

        [TestMethod]
        public void SubtractionTest()
        {
            Assert.AreEqual(calc.SubtractionNumbers(5, 6), -1);
            Assert.AreEqual(calc.SubtractionNumbers(-1, -1), 0);
            Assert.AreEqual(calc.SubtractionNumbers(0.000001, 1), -0.999999);
            Assert.AreEqual(calc.SubtractionNumbers(1234567, 23456), 1211111);
        }

        [TestMethod]
        public void DivisionTest()
        {
            Assert.AreEqual(calc.DivisionNumbers(8, 2), 4);
            Assert.AreEqual(calc.DivisionNumbers(100, -5), -20);
            Assert.AreEqual(calc.DivisionNumbers(0, 1000), 0);
            Assert.ThrowsException<ArgumentException>(() => calc.DivisionNumbers(1, 0));
        }

        [TestMethod]
        public void MultiplicationTest()
        {
            Assert.AreEqual(calc.MultiplicationNumbers(777, 420), 326340);
            Assert.AreEqual(calc.MultiplicationNumbers(-1, 6), -6);
            Assert.AreEqual(calc.MultiplicationNumbers(-1, 1), -1);
        }

        [TestMethod]
        public void AverageTest()
        {
            double[] Array = { 1, 2, 3, 4 };
            Assert.AreEqual(calc.Average(Array), 2.5);
        }
    }
}