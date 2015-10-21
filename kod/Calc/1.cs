using System;

namespace Calc
{
    // taki kod też działa
    public class Program
    {
        public static int Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("Wrong arguments!");
                return int.MinValue;
            }

            if (args[0] == "sum")
            {
                int sum = 0;

                for (int i = 1; i < args.Length; i++)
                {
                    sum += int.Parse(args[i]);
                }

                Console.WriteLine("Sum: {0}", sum);
                return sum;
            }

            if (args[0] == "product")
            {
                int product = 1;

                for (int i = 1; i < args.Length; i++)
                {
                    product *= int.Parse(args[i]);
                }

                Console.WriteLine("Product: {0}", product);
                return product;
            }

            if (args[0] == "aseq")
            {
                int[] arithmetic = new int[args.Length - 1];
                int common_difference;

                arithmetic[0] = Int32.Parse(args[1]);
                arithmetic[1] = Int32.Parse(args[2]);
                common_difference = arithmetic[1] - arithmetic[0];

                for (int i = 3; i <= args.Length - 1; i++)
                {
                    arithmetic[i-1] = Int32.Parse(args[i]);
                    Console.WriteLine("{0} - {1} == {2}", arithmetic[i-1], arithmetic[i-2], common_difference);
                    if ((arithmetic[i - 1] - arithmetic[i - 2]) == common_difference)
                    {
                    } else
                    {
                        Console.WriteLine("Sequence isn't arithmetic.");
                        return 0;
                    }
                }
                
                Console.WriteLine("Sequence is arithmetic.");
                return 1;
            }

            if (args[0] == "ndec")
            {
                int[] descending = new int[args.Length - 1];

                descending[0] = Int32.Parse(args[1]);

                for (int i = 2; i <= args.Length - 1; i++)
                {
                    descending[i - 1] = Int32.Parse(args[i]);
                    Console.WriteLine("{0} < {1}", descending[i - 1], descending[i - 2]);
                    if (descending[i - 1] < descending[i - 2])
                    {
                    }
                    else
                    {
                        Console.WriteLine("Sequence isn't descending.");
                        return 0;
                    }
                }

                Console.WriteLine("Sequence is descending.");
                return 1;
            }

                return int.MinValue;
        }
    }
}
