using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    public static class ExceptionAssert
    {
        public static void Thows<TException>(Action a) where TException : Exception
        {
            Exception exception = null;
            try
            {
                a();
            }
            catch (Exception e)
            {
                exception = e;
                Assert.IsInstanceOfType(e, typeof(TException), "Exception should be of type {0} was expected, but was{1}", typeof(TException), e.GetType());
            }

            Assert.IsNotNull(exception, "Exception should have been thrown but was not.");
        }
    }
}