using System;

namespace ConvertNumberToCorrespondingMonthName
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine(MonthName(3));
            Console.WriteLine(MonthName(12));    
            Console.WriteLine(MonthName(6));
        }
        public static string MonthName( int number)
        {
            switch (number)
            {
                case 1:
                    return "January";
                
                case 2:
                    return "February";
                
                case 3:
                    return  "March";
                    
                case 4:
                    return "April";
                    
                case 5:
                    return  "May";
                    
                case 6:
                    return "June";
                    
                case 7:
                    return "July";
                    
                case 8:
                    return "August";
                    
                case 9:
                    return "September";
                    
                case 10:
                    return "October";
                   
                case 11:
                    return "November";
                    
                case 12:
                    return "December";
                    
                default: return number.ToString();
            }
        }
    }
}
