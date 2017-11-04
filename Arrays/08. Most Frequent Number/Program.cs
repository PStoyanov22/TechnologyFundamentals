using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Most_Frequent_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            ushort[] line =  Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(ushort.Parse)
                .ToArray();

            ushort mostFrequentNumber = 0;
            ushort count = 0;
            ushort maxCount = 0;

            for (int i = 0; i < line.Length - 1; i++)
            {
                count++;
                if (count > maxCount)
                {
                    mostFrequentNumber = line[i];
                }
            }
        }
    }
}
