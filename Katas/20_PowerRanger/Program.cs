using System;

namespace _20_PowerRanger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Solutions:");
            Console.WriteLine(PowerRanger(2, 49, 65));
            Console.WriteLine(PowerRanger(3, 1, 27));
            Console.WriteLine(PowerRanger(10, 1, 5));
            Console.WriteLine(PowerRanger(5, 31, 33));
            Console.WriteLine(PowerRanger(4, 250, 1300));
        }
       
         public static int PowerRanger(int power, int min, int max)
        {
            //Math.Ceiling rounds a number Down to a round number
            int lowestRoot = (int)Math.Ceiling(Math.Pow(min, 1.0 / power));
            //Math.Floor rounds a number UP to a round number
            int highestRoot = (int)Math.Floor(Math.Pow(max, 1.0 / power));

            return highestRoot - lowestRoot + 1;
        }
       
    }
}
