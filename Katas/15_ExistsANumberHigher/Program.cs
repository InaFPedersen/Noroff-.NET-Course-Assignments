using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExistsANumberHigher
{
    internal class Program
    {
        static void Main()
        {
            int[] givenNumbers = new int[] { 5, 3, 15, 22, 4 };
            Console.WriteLine(existsHigher(givenNumbers, 10));
            //int[] givenNumbers = new int[] { 1, 2, 3, 4, 5 };
            //Console.WriteLine(existsHigher(givenNumbers, 8));
            //int[] givenNumbers = new int[] { 4, 3, 3, 3, 2, 2, 2 };
            //Console.WriteLine(existsHigher(givenNumbers, 4));
            //int[] givenNumbers = new int[] { -10, -99, -57, -4 };
            //Console.WriteLine(existsHigher(givenNumbers, -4));
            //int[] givenNumbers = new int[] { 5 };
            //Console.WriteLine(existsHigher(givenNumbers, 5));
            //int[] givenNumbers = new int[] { 99 };
            //Console.WriteLine(existsHigher(givenNumbers, 99));
            //int[] givenNumbers = new int[] { };
            //Console.WriteLine(existsHigher(givenNumbers, 5));
        }
        public static bool existsHigher(int[] givenNumbers, int checkNumber)
        {

            foreach (var numbers in givenNumbers)
            {
                if (numbers >= checkNumber)
                {
                    return true;
                }

            }

            return false;

        }
    }
}
