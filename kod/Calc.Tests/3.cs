using System;
using System.Collections.Generic;
using System.Linq;
using Calc;
using FakeItEasy;
using NUnit.Framework;

namespace Calculator.Tests
{
    [TestFixture]
    public class ProgTests
    {
        [SetUp]
        public void SetUp()
        {
            _calculator = A.Fake<ICalculator>();
            _sut = new Prog(_calculator);
        }

        private ICalculator _calculator;
        private Prog _sut;

        [Test]
        public void Run_Should_Call_Calculator_With_Sum_Operation_When_First_Arg_Was_sum()
        {
            _sut.Run(new[] { "sum" });

            A.CallTo(() => _calculator.Calculate(Operation.Sum, A<IEnumerable<int>>._))
                .MustHaveHappened();
        }

        [Test]
        public void Should_Return_IntMin_When_Calculator_Thows_Exception()
        {
            // arange
            A.CallTo(() => _calculator.Calculate(A<Operation>._, A<IEnumerable<int>>._))
                .Throws<ArgumentOutOfRangeException>();

            var expected = int.MinValue;

            var actual = _sut.Run(new[] { "sum" });

            Assert.AreEqual(expected, actual);
        }
    }

    [TestFixture]
    public class CalculatorTests
    {
        [SetUp]
        public void Setup()
        {
            _sut = new Calc.Calculator();
        }

        private Calc.Calculator _sut;

        [Test]
        public void Should_Throw_Exception_When_Unsupported_Operation_Is_Given()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _sut.Calculate((Operation)10, Enumerable.Empty<int>()));
        }

        [Test]
        public void Should_Throw_Exception_When_Unsupported_Operation_Is_Given_With_Proper_ParamName()
        {
            string exprectedParamName = "op";
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => _sut.Calculate((Operation)10, Enumerable.Empty<int>()));
            Assert.That(exception.ParamName, Is.EqualTo(exprectedParamName));
        }
    }
}