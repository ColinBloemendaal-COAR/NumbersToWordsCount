using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersToWordsCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the value of which you want to start from (> 0 && < 21): ");
            string sta = Console.ReadLine();
            Console.WriteLine("Enter the value of which you want the program to stop at (> 0 && < 21): ");
            string end = Console.ReadLine();
            Int32.TryParse(sta, out int st);
            Int32.TryParse(end, out int en);
            int TotalCount = TotalCharCount(st, en);
            Console.WriteLine("The total count of characters from the letter " + st + " to " + en + " is: " + TotalCount);


            // 132 = honderd en twee en dertig


            Console.Write("Press <Enter> to exit... ");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }

        }


 

        public static int TotalCharCount(int st, int en)
        {
            int count = 0;
            for(int i = st; i <= en; i++)
            {
                count += GetCharCount(Get1to20(i));
            }
            return count;
        }

        public static int GetCharCount(string s)
        {
            if(string.IsNullOrEmpty(s))
                return 0;
            int count = 0;
            foreach(char c in s)
            {
                count++;
            }
            return count;
        }
        
        public static string Get1to20(int num)
        {
            if(num > 0 && num <= 20)
            {
                switch (num)
                {
                    case 1:
                        return "Een";
                    case 2:
                        return "Twee";
                    case 3:
                        return "Drie";
                    case 4:
                        return "Vier";
                    case 5:
                        return "Vijf";
                    case 6:
                        return "Zes";
                    case 7:
                        return "Zeven";
                    case 8:
                        return "Acht";
                    case 9:
                        return "Negen";
                    case 10:
                        return "Tien";
                    case 11:
                        return "Elf";
                    case 12:
                        return "Twaalf";
                    case 13:
                        return "Dertien";
                    case 14:
                        return "Viertien";
                    case 15:
                        return "Vijftien";
                    case 16:
                        return "Zestien";
                    case 17:
                        return "Zeventien";
                    case 18:
                        return "Achtien";
                    case 19:
                        return "Negentien";
                    case 20:
                        return "Twintig";
                    default:
                        return "";
                }
            }
            return "";
        }
    }
}
