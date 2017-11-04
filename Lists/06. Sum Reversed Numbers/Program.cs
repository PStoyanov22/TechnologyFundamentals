using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Sum_Reversed_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
              List<int> numbers = Console.ReadLine()
                 .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)               
                 .Select(int.Parse)
                 .ToList();
           
              int sum = 0;
              int reverse = 0;
            int remainder = 0;
            List<int> newSequence = new List<int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                while (numbers[i] > 0)
                {
                    remainder = numbers[i] % 10;
                    reverse = (reverse * 10) + remainder;
                    numbers[i] = numbers[i] / 10;
                }
                remainder = 0;

                newSequence.Add(reverse);
                reverse = 0;
                
            }
            for (int i = 0; i < newSequence.Count; i++)
            {
                sum += newSequence[i];
            }
            Console.WriteLine(sum);                          
        }
    }
}
