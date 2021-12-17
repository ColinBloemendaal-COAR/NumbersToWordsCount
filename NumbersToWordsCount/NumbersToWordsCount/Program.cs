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
                count += GetCharCount(SplitNumber(i));
            }
            return count;
        }

        // Split the original number in its own parts: 932 = 900, 30, 2
        public static string SplitNumber(int num)
        {
            string numW = num.ToString();
            int numLength = numW.Length;
            string feedback = "";

            // Check how long the numeric value is
            if (numLength == 1)
            {
                feedback += GetUnique(num);
            }
            else if (numLength == 2)
            {
                if (num <= 20 && num > 0)
                {
                    GetUnique(num);
                }
                else if (num > 20)
                {
                    // Loop through the number given by the function param.
                    double[] array = new double[numLength];
                    for (int i = 0; i < numW.Length; i++)
                    {
                        Double.TryParse(numW[i].ToString(), out double proccesNum);
                        array[i] = proccesNum;
                    }
                    Array.Reverse(array);
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (i > 0)
                            array[i] *= Math.Pow(10, i);
                    }

                    // Return the values in plain text
                    foreach (int j in array)
                    {
                        feedback += GetUnique(j);
                    }
                    // Enable this line of code to view what text is being generated
                    //Console.WriteLine(feedback);
                }

            }
            else if (numLength == 3)
            {
                if (num <= 20 && num > 0)
                {
                    GetUnique(num);
                }
                else if (num > 20)
                {
                    // Loop through the number given by the function param.
                    double[] array = new double[numLength];
                    for (int i = 0; i < numW.Length; i++)
                    {
                        Double.TryParse(numW[i].ToString(), out double proccesNum);
                        array[i] = proccesNum;
                    }

                    // check if last 2 numbers together is a unique num
                    string arr1 = array[array.Length - 1].ToString();
                    string arr2 = array[array.Length - 2].ToString();
                    string arr3 = arr2 + arr1;
                    int checkUniqueLast = Convert.ToInt32(arr3);

                    if (CheckUnique(checkUniqueLast) == true)
                    {
                        array[array.Length -2] = Convert.ToDouble(checkUniqueLast);
                        array[array.Length -1] = 0;
                    }
                    else
                    {

                    }
                    Array.Reverse(array);
                    for (int i = 0; i < array.Length - 2; i++)
                    {
                        if (i > 0)
                            array[i] *= Math.Pow(10, i);
                    }

                    // Return the values in plain text
                    foreach (int j in array)
                    {
                        feedback += GetUnique(j);
                    }
                    // Enable this line of code to view what text is being generated
                    Console.WriteLine(feedback);
                }
            }
            else if (numLength == 4)
            {

            }
            else if (numLength == 5)
            {

            }
            return feedback;
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
                    case 30:
                        return "Dertig";
                    case 40:
                        return "Veertig";
                    case 50:
                        return "Vijftig";
                    case 60:
                        return "Zestig";
                    case 70:
                        return "Zeventig";
                    case 80:
                        return "Tachtig";
                    case 90:
                        return "Negentig";
                    case 100:
                        return "Honderd";
                    case 1000:
                        return "Duizend";
                    case 10000:
                        return "Tienduizend";
                    case 100000:
                        return "HonderdDuizend";
                    case 1000000:
                        return "Miljoen";
                    default:
                        return "";
                }
            }
            return "";
        }
    }
}
