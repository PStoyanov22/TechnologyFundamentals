using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Equal_Sums
{
    class Program
    {
        static void Main(string[] args)
        {
            //   int[] numbers = Console.ReadLine()
            //       .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            //       .Select(int.Parse)
            //       .ToArray();
            //
            //   bool isFound = false;
            //
            //   for (int i = 0; i < numbers.Length; i++)
            //   {
            //       int[] leftSide = numbers.Take(i).ToArray();
            //       int[] rightSide = numbers.Skip(i + 1).ToArray();
            //
            //       if (leftSide.Sum() == rightSide.Sum())
            //       {
            //           Console.WriteLine(i);
            //           isFound = true;
            //           break;
            //       }
            //       
            //   }
            //   if (isFound)
            //   {
            //       Console.WriteLine("pepelyashka");
            //   }
            //  

            {
                int[] numbers = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int i = 0; i < numbers.Length; i++)
                {
                    int[] leftSide = numbers.Take(i).ToArray();
                    int[] rightSide = numbers.Skip(i + 1).ToArray();

                    if (leftSide.Sum() == rightSide.Sum())
                    {
                        Console.WriteLine(i);
                        return;
                    }
                    else
                    {
                        continue;
                    }
                }
                Console.WriteLine("no");
            }



        }
    }
}
