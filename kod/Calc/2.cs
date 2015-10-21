using System;
using System.Linq;

namespace Calc
{
    public class Program2
    {
        public static int Main(string[] args)
        {
            return (args == null || args.Length == 0 || (args[0] != "sum" && args[0] != "product" && args[0] != "aseq" && args[0] != "ndec"))
                ? int.MinValue
                : args[0] == "sum"
                    ? args.Skip(1).Select(int.Parse).Aggregate(0, (a, b) => a + b)
                    : args[0] == "product"
                        ? args.Skip(1).Select(int.Parse).Aggregate(0, (a, b) => a * b)
                        : args[0] == "aseq"
                            ? aseq(args)
                            : ndec(args);


            //string test = (args == null || args.Length == 0 || (args[0] != "sum" && args[0] != "product" && args[0] != "aseq" && args[0] != "ndec"))
            //? "chyjnia"
            //: args[0] == "sum"
            //    ? "sum"
            //    : args[0] == "product"
            //        ? "product"
            //        : args[0] == "aseq"
            //            ? "aseq"
            //            : "ndec";

            //Console.WriteLine(test);
            //return 0;
        }

        public static int aseq(string[] args)
        {
            Console.WriteLine("im here");
            int[] arithmetic = new int[args.Length - 1];
            int common_difference;

            arithmetic[0] = Int32.Parse(args[1]);
            arithmetic[1] = Int32.Parse(args[2]);
            common_difference = arithmetic[1] - arithmetic[0];

            for (int i = 3; i <= args.Length - 1; i++)
            {
                arithmetic[i - 1] = Int32.Parse(args[i]);
                Console.WriteLine("{0} - {1} == {2}", arithmetic[i - 1], arithmetic[i - 2], common_difference);
                if ((arithmetic[i - 1] - arithmetic[i - 2]) == common_difference)
                {
                }
                else
                {
                    Console.WriteLine("Sequence isn't arithmetic.");
                    return 0;
                }
            }

            Console.WriteLine("Sequence is arithmetic.");
            return 1;
        }

        public static int ndec(string[] args)
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
    }
}