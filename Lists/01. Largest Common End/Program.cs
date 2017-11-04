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
            var number = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int length = 1;
            int maxLegth = 1;
            int startNumber = 0;

            for (int i = 0; i < number.Count - 1; i++)
            {
                if (number[i] == number[i + 1])
                {
                    length++;
                    if (length > maxLegth)
                    {
                        maxLegth = length;
                        startNumber = number[i];
                    }

                }
                if (number[i] != number[i + 1])
                {
                    length = 1;

                }

            }

            if (length > 1)
            {
                for (int i = 0; i < maxLegth; i++)
                {
                    Console.Write(startNumber + " ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine(number[0]);
            }
        }
    }
}
