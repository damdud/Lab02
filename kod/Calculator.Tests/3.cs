using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Calculator.Tests
{
    [TestClass]
    public class ProgTests
    {
        private Mock<ICalculator> _calculatorMock;

        private Prog _sut;

        [TestInitialize]
        public void SetUp()
        {
            _calculatorMock = new Mock<ICalculator>();
            _sut = new Prog(_calculatorMock.Object);
        }

        [TestMethod]
        public void Run_Should_Call_Calculator_With_Sum_Operation_When_First_Arg_Was_sum()
        {
            // arange
            _calculatorMock
                .Setup(x => x.Calculate(It.IsAny<Operation>(), It.IsAny<IEnumerable<int>>()))
                .Returns(0);

            _sut.Run(new[] { "sum" });

            _calculatorMock
                .Verify(x => x.Calculate(Operation.Sum, It.IsAny<IEnumerable<int>>()), Times.Once);
        }

        [TestMethod]
        public void Should_Return_IntMin_When_Calculator_Thows_Exception()
        {
            // arange
            _calculatorMock
                .Setup(x => x.Calculate(It.IsAny<Operation>(), It.IsAny<IEnumerable<int>>()))
                .Throws<ArgumentOutOfRangeException>();
            int expected = int.MinValue;

            int actual = _sut.Run(new[] { "sum" });

            Assert.AreEqual(expected, actual);
        }
    }

    [TestClass]
    public class CalculatorTests
    {
        private Calculator _sut;

        [TestInitialize]
        public void Setup()
        {
            _sut = new Calculator();
        }

        [TestMethod]
        public void Should_Throw_Exception_When_Unsupported_Operation_Is_Given()
        {
            ExceptionAssert.Thows<ArgumentOutOfRangeException>(() => _sut.Calculate((Operation)10, Enumerable.Empty<int>()));
        }
    }
}