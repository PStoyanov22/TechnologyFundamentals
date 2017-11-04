using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Compare_Char_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] lineOne = Console.ReadLine()
                .Split( ' ' )
                .Select(char.Parse)
                .ToArray();

            char[] lineTwo = Console.ReadLine()
                .Split(' ')
                .Select(char.Parse)
                .ToArray();

            int length = Math.Min(lineOne.Length, lineTwo.Length);


            for (int i = 0; i < length; i++)
            {
                if (lineOne[i] == lineTwo[i])
                {
                    continue;
                }
                if (lineOne[i] < lineTwo[i])
                {
                    Console.WriteLine(string.Join("", lineOne));
                    Console.WriteLine(string.Join("", lineTwo));
                    return;
                }
                else if (lineTwo[i] < lineOne[i])
                {
                    Console.WriteLine(string.Join("", lineTwo));
                    Console.WriteLine(string.Join("", lineOne));
                    return;
                }
                
            }
            if (lineOne.Length < lineTwo.Length)
            {
                Console.WriteLine(string.Join("", lineOne));
                Console.WriteLine(string.Join("", lineTwo));
                
            }
            else if (lineTwo.Length < lineOne.Length)
            {
                Console.WriteLine(string.Join("", lineTwo));
                Console.WriteLine(string.Join("", lineOne));
            }
            else
            {
                Console.WriteLine(string.Join("", lineTwo));
                Console.WriteLine(string.Join("", lineOne));
            }
        }


        static 
    }
}
