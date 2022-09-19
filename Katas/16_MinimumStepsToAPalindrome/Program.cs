using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumStepsToAPalindrome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine(minPalindromeSteps("race"));
            Console.WriteLine(minPalindromeSteps("mada"));
            Console.WriteLine(minPalindromeSteps("mirror"));
            Console.WriteLine(minPalindromeSteps("TACOcat"));
            Console.WriteLine(minPalindromeSteps("noroff"));

        }
        public static string reverseWord(string word)
        {
            string revWord = "";
            for(int i = word.Length - 1; i >= 0; i--)
            {
                revWord += word[i];
            }
            return revWord;
        }

        public static bool isPalindrome(string word)
        {
            return reverseWord(word).ToLower() == word.ToLower();
        }
        /// <summary>
        /// Find the minimum number of steps to obtain a palindrome!
        /// </summary>
        /// <param name="incompletePalindrome"></param>
        /// <returns></returns>
        public static int minPalindromeSteps(string incompletePalindrome)
        {
            string possibility = "";
            for(int i = 0; i < incompletePalindrome.Length; i++)
            {
                possibility = incompletePalindrome + reverseWord(incompletePalindrome);
                if (isPalindrome(possibility))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
