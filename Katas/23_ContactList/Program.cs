using System;
using System.Linq;

namespace _23_ContactList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("First solution: ");
            foreach (var item in SortContacts(new string[] {
                                                          "John Locke",
                                                          "Thomas Aquinas",
                                                          "David Hume",
                                                          "Rene Descartes"
                                                        }, "ASC"))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("");
            Console.WriteLine("Second solution: ");
            foreach (var name in SortContacts(new string[] {
                                                          "Paul Erdos",
                                                          "Leonhard Euler",
                                                          "Carl Gauss"
                                                        }, "DESC"))
            {
                Console.WriteLine(name);
            }
            
        }

        public static string[] SortContacts(string[] names, string order)
        {
            var query = names.OrderBy(x => x.Split(' ')[1]);
            if(order == "ASC") return query.ToArray();
            return query.Reverse().ToArray();
        }
    }
}
