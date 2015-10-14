using System;
using System.Collections.Generic;
using System.Linq;

namespace Calc
{
    public interface ICalculator
    {
        int Calculate(Operation op, IEnumerable<int> arguments);
    }

    public class Calculator : ICalculator
    {
        public int Calculate(Operation op, IEnumerable<int> arguments)
        {
            switch (op)
            {
                case Operation.Sum:
                    return arguments.Aggregate(0, (a, b) => a + b);
                case Operation.Product:
                    return arguments.Aggregate(1, (a, b) => a * b);
                default:
                    throw new ArgumentOutOfRangeException(nameof(op), op, "unknown operation");
            }
        }
    }

    public enum Operation
    {
        Sum,
        Product
    }

    public class Prog
    {
        private readonly ICalculator _calculator;

        public Prog(ICalculator calculator)
        {
            _calculator = calculator;
        }

        public int Run(string[] args)
        {
            Operation operation;
            if (args == null || args.Length == 0 || !Enum.TryParse(args.First(), true, out operation))
            {
                return int.MinValue;
            }

            var arguments = args.Skip(1).Select(int.Parse).ToList();

            try
            {
                return _calculator.Calculate(operation, arguments);
            }
            catch (ArgumentOutOfRangeException)
            {
                return int.MinValue;
            }
        }
    }

    public class Program3
    {
        public static int Main(string[] args)
        {
            return new Prog(new Calculator()).Run(args);
        }
    }
}