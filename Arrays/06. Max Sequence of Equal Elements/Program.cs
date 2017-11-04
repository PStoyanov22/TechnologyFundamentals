using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] line = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int startSequence = 0;
            int MaxLength = 1;
            int length = 1;

            for (int i = 0; i < line.Length-1; i++)
            {
                if (line[i] == line[i + 1])
                {                   
                    length++;
                    if (length > MaxLength)
                    {
                        startSequence = line[i];
                        MaxLength = length;
                    }

                }
                else if (line[i] != line[i + 1])
                {
                    
                    length = 1;
                    
                }
            }

            for (int i = 0; i < MaxLength; i++)
            {
                Console.Write($"{startSequence} ");
            }
            Console.WriteLine();
        }
    }
}
