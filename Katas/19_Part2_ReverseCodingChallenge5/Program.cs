using System;

namespace _19_Part2_ReverseCodingChallenge5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Solutions:");
            Console.WriteLine(ReverseInt(832));
            Console.WriteLine(ReverseInt(51));
            Console.WriteLine(ReverseInt(7977));
            Console.WriteLine(ReverseInt(1));
            Console.WriteLine(ReverseInt(665));
            Console.WriteLine(ReverseInt(149));
        }

        public static int ReverseInt(int inputNumber)
        {
            return inputNumber - SortDigits(inputNumber);
        }
        private static int SortDigits(int givenNumber)
        {
            char[] digits = givenNumber.ToString().ToCharArray();
            Array.Sort(digits);
            return Convert.ToInt32(new string(digits));
        }
    }
}
