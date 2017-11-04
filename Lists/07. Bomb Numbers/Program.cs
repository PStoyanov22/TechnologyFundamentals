using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> numbers = Console.ReadLine()
               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();


            var bombSequence = Console.ReadLine()
               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            int bombNumber = bombSequence[0];
            int power = bombSequence[1];
            int startRemovedNumbers = 0;
            int removedCount = 0;


            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == bombNumber)
                {

                    if (i - (power ) < 0 ) 
                    {
                        startRemovedNumbers = 0;
                        if ((power + i) >= numbers.Count)
                            {
                                removedCount = numbers.Count;
                            }
                        else
                        {
                            removedCount = power + 1 + i;
                        }
                        

                    }
                    else
                    {
                        startRemovedNumbers = (i - (power));

                        if ((power + i) >= numbers.Count)
                        {
                            removedCount = numbers.Count - startRemovedNumbers;
                        }
                        else
                        {
                            removedCount = ((2 * power) + 1);
                        }
                    }

                   

                    numbers.RemoveRange(startRemovedNumbers, removedCount);

                    i = 0;
                
                }
            }
            

            int sum = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }
            Console.WriteLine(sum);


        }
    }
}