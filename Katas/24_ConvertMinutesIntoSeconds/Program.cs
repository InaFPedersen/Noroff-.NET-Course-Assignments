using System;

namespace _24_ConvertMinutesIntoSeconds
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Solutions:"); Console.WriteLine(convert(5)); Console.WriteLine(convert(3)); Console.WriteLine(convert(2));
        }
        public static int convert(int number) { int convertToSeconds = number * 60; return convertToSeconds; }
    }
}
