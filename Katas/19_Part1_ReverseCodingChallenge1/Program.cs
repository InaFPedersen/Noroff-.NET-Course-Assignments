using System;

namespace ReverseCodingChallenge1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Solutions:");
            Console.WriteLine(reverseString("A4B5C2"));
            Console.WriteLine(reverseString("C2F1E5"));
            Console.WriteLine(reverseString("T4S2V2"));
            Console.WriteLine(reverseString("A1B2C3D4"));
        }

        public static string reverseString(string inputString)
        {
            string result = "";
            for(int i = 0; i < inputString.Length; i+=2)
                result += new string(inputString[i], int.Parse((inputString[i + 1]).ToString()));
                return result;
           
        }
    }
}
