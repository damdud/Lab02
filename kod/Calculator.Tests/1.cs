using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Main_Returns_IntMin_When_Null_Args()
        {
            // arrange
            int expected = int.MinValue;

            // act
            int actual = Program.Main(null);

            // assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Main_Returns_IntMin_When_Empty_Args()
        {
            int expected = int.MinValue;

            // act
            int actual = Program.Main(new string[] { });

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Main_Returns_IntMin_When_First_Arg_Not_sum_Or_product()
        {
            int expected = int.MinValue;

            // act
            int actual = Program.Main(new[] { "limes"});

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Main_Returns_Zero_When_There_Is_Only_One_Argument_string_sum()
        {
            int expected = 0;

            int actual = Program.Main(new[] { "sum" });

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Main_Returns_Sum_Of_All_Remaining_Arguments_After_sum_String()
        {
            string[] sumArguments = {"sum", "2", "4", "6"};
            int expected = 12;

            int actual = Program.Main(sumArguments);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Main_Returns_One_When_There_Is_Only_One_Argument_string_product()
        {
            int expected = 1;

            int actual = Program.Main(new[] { "product" });

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Main_Returns_Product_Of_All_Remaining_Arguments_After_product_String()
        {
            string[] sumArguments = { "product", "2", "5", "3" };
            int expected = 30;

            int actual = Program.Main(sumArguments);

            Assert.AreEqual(expected, actual);
        }
    }
}