using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersToWordsCount
{
    internal class Program
    {

        static void Main(string[] args)
        {
            bool Application = true;
            while (Application)
            {
                string sta = String.Empty;
                string end = String.Empty;
                while(CheckInput(sta) == false)
                {
                    Console.WriteLine("Enter the value of which you want to start from (larger then 0): ");
                    sta = Console.ReadLine();
                }

                while (CheckInput(end) == false)
                {
                    Console.WriteLine("Enter the value of which you want the program to stop at (larger then 0): ");
                    end = Console.ReadLine();
                }

                ReturnResult(sta, end);


                Application = ExitProgram();
            }
        }

        public static bool CheckInput(string s)
        {
            if(!string.IsNullOrEmpty(s) && IsInt(s) && GetInt(s) > 0)
                return true;
            return false;

        }

        public static void ReturnResult(string sta, string end )
        {
            if (GetInt(sta) > GetInt(end))
            {
                Console.WriteLine("The starting value must be lower then the ending value");
                return;
            }
            int TotalCount = TotalCharCount(sta, end);
            Console.WriteLine("The total count of characters from the letter " + sta + " to " + end + " is: " + TotalCount);
        }

        public static bool IsInt(string s)
        {
            if(Int32.TryParse(s, out int i))
                return true;
            return false;
        }

        public static int GetInt(string s)
        {
            Int32.TryParse(s, out int i);
            return i;
        }

        public static bool ExitProgram()
        {
            Console.Write("Press <Escape> to exit or press <Enter> to start over.");

            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
            } while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape);

            if (key.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
                return false;
            }
            if (key.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                return true;
            }
            return false;
        }

        public static int TotalCharCount(string s, string e)
        {
            int st = GetInt(s);
            int en = GetInt(e);
            int count = 0;
            for(int i = st; i <= en; i++)
            {
                count += GetCharCount(SplitNumber(i));
            }
            return count;
        }

        // Split the original number in its own parts: 932 = 900, 30, 2
        public static string SplitNumber(int num)
        {
            if (num <= 0)
                return "";

            string numW = num.ToString();
            int numLength = numW.Length;

            string returnFeed = "";

            // Set every digit of the number in its own array index
            double[] array = new double[numLength];
            for (int i = 0; i < numW.Length; i++)
            {
                Double.TryParse(numW[i].ToString(), out double proccesNum);
                array[i] = proccesNum;
            }

            int lastTwo = 0;
            if(numLength == 1)
                lastTwo = Convert.ToInt32(((int)array[0]).ToString());
            else 
                lastTwo = Convert.ToInt32(array[array.Length - 2].ToString() + array[array.Length - 1].ToString());

            int TensOfThousands = 0;
            if(numLength >= 5 && num >= 10000)
                TensOfThousands = Convert.ToInt32(array[array.Length - 5].ToString() + array[array.Length - 4].ToString());

            
            if (CheckUnique(lastTwo) == true)
            {
                if(numLength >= 2)
                    array[array.Length - 2] = 0;
                array[array.Length - 1] = Convert.ToInt32(lastTwo);
            }

            // Reverse the array so the index is in a corresponding position with the math function to the power of.
            // Array index 2 is in math to the power of 2 > num * (10 * the power of 2)
            Array.Reverse(array);
            for (int i = 0; i < array.Length; i++)
            {
                if(i > 0)
                    array[i] *= Math.Pow(10, i);
            }

            Array.Reverse(array);
            // Return the values in plain text
            foreach (int a in array)
            {
                returnFeed += GetUnique(a);
            }

            // Enable this line of code to view what text is being generated
            Console.WriteLine(returnFeed);

            return returnFeed;
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

        public static bool CheckUnique(int num)
        {
            string numW = GetUnique(num);
            if(!string.IsNullOrEmpty(numW))
                return true;
            return false;
        }

        public static string GetUnique(int num)
        {
            if (num > 0)
            {
                switch (num)
                {
                    case 1: return "Een";
                    case 2: return "Twee";
                    case 3: return "Drie";
                    case 4: return "Vier";
                    case 5: return "Vijf";
                    case 6: return "Zes";
                    case 7: return "Zeven";
                    case 8: return "Acht";
                    case 9: return "Negen";
                    case 10: return "Tien";
                    case 11: return "Elf";
                    case 12: return "Twaalf";
                    case 13: return "Dertien";
                    case 14: return "Viertien";
                    case 15: return "Vijftien";
                    case 16: return "Zestien";
                    case 17: return "Zeventien";
                    case 18: return "Achtien";
                    case 19: return "Negentien";
                    case 20: return "Twintig";
                    case 30: return "Dertig";
                    case 40: return "Veertig";
                    case 50: return "Vijftig";
                    case 60: return "Zestig";
                    case 70: return "Zeventig";
                    case 80: return "Tachtig";
                    case 90: return "Negentig";
                    case 100: return "Honderd";
                    case 200: return "Tweehonderd";
                    case 300: return "Driehonderd";
                    case 400: return "Vierhonderd";
                    case 500: return "Vijfhonderd";
                    case 600: return "Zeshonderd";
                    case 700: return "Zevenhonderd";
                    case 800: return "Achthonderd";
                    case 900: return "Negenhonderd";
                    case 1000: return "Duizend";
                    case 2000: return "Tweeduizend";
                    case 3000: return "Drieduizend";
                    case 4000: return "Vierduizend";
                    case 5000: return "Vijfduizend";
                    case 6000: return "Zesduizend";
                    case 7000: return "Zevenduizend";
                    case 8000: return "Achtduizend";
                    case 9000: return "Negenduizend";
                    case 10000: return "Tienduizend";
                    case 20000: return "Twintigduizend";
                    case 30000: return "Dertigduizend";
                    case 40000: return "Veertigduizend";
                    case 50000: return "Vijfitduizend";
                    case 60000: return "Zestigduizend";
                    case 70000: return "Zeventigduizend";
                    case 80000: return "Tachtigduizend";
                    case 90000: return "Negentigduizend";
                    case 100000:return "HonderdDuizend";
                    case 1000000: return "Miljoen";
                    default:
                        return "";
                }
            }
            return "";
        }
    }
}
