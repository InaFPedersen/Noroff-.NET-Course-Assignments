using System;

namespace _21_SmoothSentences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Solutions");
            Console.WriteLine(IsSmooth("Marta appreciated deep perpendicular right trapezoids"));
            Console.WriteLine(IsSmooth("Someone is outside the doorway"));
            Console.WriteLine(IsSmooth("She eats super righteously"));
        }
        
        public static bool IsSmooth(string sentence)
        {
            sentence = sentence.Trim().ToLower();
            string[] sentences = sentence.Split(' ');

            if(sentences.Length <= 1) return false;

            for(int i = 0; i < sentences.Length - 1; i++)
            {
                string previousWord = sentences[i];
                char lastCharacter = Char.Parse(previousWord.Substring(previousWord.Length - 1));

                string followingWord = sentences[i + 1];
                char firstCharacter = Char.Parse(followingWord.Substring(0, 1));

                if(lastCharacter != firstCharacter) return false;

            }
            return true;
        }
    }
}
