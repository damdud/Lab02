using Calc;
using NUnit.Framework;
using SUT = Calc.Program2;

namespace Calculator.Tests
{
    [TestFixture]
    public class ProgramTests
    {
        [Test]
        public void Main_Returns_IntMin_When_Null_Args()
        {
            // arrange
            int expected = int.MinValue;

            // act
            int actual = SUT.Main(null);

            // assert
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Main_Returns_IntMin_When_Empty_Args()
        {
            int expected = int.MinValue;

            // act
            int actual = SUT.Main(new string[] { });

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Main_Returns_IntMin_When_First_Arg_Not_sum_Or_product()
        {
            int expected = int.MinValue;

            // act
            int actual = SUT.Main(new[] { "limes"});

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Main_Returns_Zero_When_There_Is_Only_One_Argument_string_sum()
        {
            int expected = 0;

            int actual = SUT.Main(new[] { "sum" });

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Main_Returns_Sum_Of_All_Remaining_Arguments_After_sum_String()
        {
            string[] sumArguments = {"sum", "2", "4", "6"};
            int expected = 12;

            int actual = SUT.Main(sumArguments);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Main_Returns_One_When_There_Is_Only_One_Argument_string_product()
        {
            int expected = 1;

            int actual = SUT.Main(new[] { "product" });

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Main_Returns_Product_Of_All_Remaining_Arguments_After_product_String()
        {
            string[] sumArguments = { "product", "2", "5", "3" };
            int expected = 30;

            int actual = SUT.Main(sumArguments);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Main_Returns_One_When_Sequence_Is_Arithemtic()
        {
            string[] aseqArguments = { "aseq", "1", "2", "3" };
            int expected = 1;

            int actual = SUT.Main(aseqArguments);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Main_Returns_Zero_When_Sequence_Is_Not_Arithemtic()
        {
            string[] aseqArguments = { "aseq", "1", "12", "3" };
            int expected = 0;

            int actual = SUT.Main(aseqArguments);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Main_Return_One_When_Sequence_Is_Descending()
        {
            string[] ndecArguments = { "ndec", "4", "3", "2", "1" };
            int expected = 1;

            int actual = SUT.Main(ndecArguments);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Main_Return_One_When_Sequence_Is_Not_Descending()
        {
            string[] ndecArguments = { "ndec", "4", "10", "0", "5" };
            int expected = 0;

            int actual = SUT.Main(ndecArguments);

            Assert.AreEqual(expected, actual);
        }
    }
}