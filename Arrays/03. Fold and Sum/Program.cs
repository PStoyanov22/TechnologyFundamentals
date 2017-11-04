using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
              int[] numbers = Console.ReadLine()
                                   .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(int.Parse)
                                   .ToArray();
            
            
              int k = numbers.Length / 4;
            
              int[] leftNumbers = numbers.Take(k).ToArray();
              int[] middleNumbers = numbers.Skip(k).Take(2 * k).ToArray();
            
              int[] rightNumbers = numbers.Skip(3 * k).Take(k).ToArray();
            
              Array.Reverse(leftNumbers);
             
              Array.Reverse(rightNumbers);
            
              int[] result = new int[k * 2];
            
              for (int i = 0; i < k; i++)
              {
                  result[i] = leftNumbers[i] + middleNumbers[i];
                  result[i + k] = middleNumbers[i + k] + rightNumbers[i];
              }
            
              Console.WriteLine($"{String.Join(" ", result)}");          

        }
    }
}
