using System;

namespace _16_ReplaceVowelWithAnotherCharacter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(replaceVowel("karAchi"));
            Console.WriteLine(replaceVowel("chEmBur"));
            Console.WriteLine(replaceVowel("khandbari"));
            Console.WriteLine(replaceVowel("LexiCAl"));
            Console.WriteLine(replaceVowel("fuNctionS"));
            Console.WriteLine(replaceVowel("karAchi"));
        }


        static string replaceVowel(string word)
        {
            word = word.ToLower();
            string characters = string.Empty;
            foreach (char c in word)
            {
                if (c == 'a')
                {
                    characters += "1";
                }
                else if (c == 'e')
                {
                    characters += "2";
                }
                else if (c == 'i')
                {
                    characters += "3";
                }
                else if (c == 'o')
                {
                    characters += "4";
                }
                else if (c == 'u')
                {
                    characters += "5";
                }
                else 
                { 
                    characters += c; 
                }
            }
            return characters;
        }
        

    }
}