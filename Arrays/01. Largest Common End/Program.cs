using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Largest_Common_End
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstArray = Console.ReadLine()
                                 .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                 .ToArray();

            string[] secondArray = Console.ReadLine()
                                  .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                  .ToArray();

            int countFromLeft = CountOfCommonWords(firstArray, secondArray);

            Array.Reverse(firstArray);
            Array.Reverse(secondArray);

            int countFromRight = CountOfCommonWords(firstArray, secondArray);

            Console.WriteLine($"{Math.Max(countFromLeft, countFromRight)}");


        }

        static int CountOfCommonWords(string[] firstArray, string[] secondArray)
        {
            int shorterArray = Math.Min(firstArray.Length, secondArray.Length);
            int count = 0;
            for (int i = 0; i < shorterArray; i++)
            {
                if (firstArray[i] == secondArray[i])
                {
                    count++;
                }
                else
                {
                    break;
                }
            }

            return count;

        }
    }    
}
