using System;
using System.Collections.Generic;

namespace _22_SumOfFactorsOfFactors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Solutions:");
            Console.WriteLine(SumFF(69));
            Console.WriteLine(SumFF(12));
            Console.WriteLine(SumFF(420));
            Console.WriteLine(SumFF(619));
           
        }

        public static int SumFF(int givenNumber)
        {
            List<int> factors = new List<int>(Factor(givenNumber));
            factors.RemoveAt(0);
            factors.RemoveAt(0);
            List<int> allFactors = new List<int>();
            int sum = 0;
            for(int i = 0; i < factors.Count; i++)
            {
                if((Factor(factors[i]).Count) != 2)
                {
                    for (int j = 0; j <Factor(factors[i]).Count; j++)
                        if(Factor(factors[i])[j] != 1 && Factor(factors[i])[j] != factors[i])
                        {
                            sum += Factor(factors[i])[j];
                            allFactors.Add(Factor(factors[i])[j]);
                        }
                }
            }
            return sum;

        }

        public static List<int> Factor(int givenNumber)
        {
            var factors = new List<int>();
            int max = (int)Math.Sqrt(givenNumber);

            for (int factor = 1; factor <= max; factor++)
            {
                if(givenNumber % factor == 0)
                {
                    factors.Add(factor);
                    if (factor != givenNumber / factor) factors.Add(givenNumber / factor);
                }
            }
            return factors;
        }
    }
}
