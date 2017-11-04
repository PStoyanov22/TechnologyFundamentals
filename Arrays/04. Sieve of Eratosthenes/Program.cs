using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Sieve_of_Eratosthenes
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            bool[] prime = new bool[number + 1];            

            for (int i = 0; i < prime.Length; i++)
            {
                prime[i] = true;
            }

            for (int i = 2; i < Math.Sqrt(number); i++)
            {

                if (prime[i])
                {
                    for (int j = i * i; j <= number; j += i)
                    {
                        prime[j] = false;                       

                    }
                }                
            }
            List<int> primeList = new List<int>();
            for (int i = 2; i < prime.Length; i++)
            {
                if (prime[i])
                {
                    primeList.Add(i);                   
                }
               
            }
            Console.WriteLine($"{String.Join(" ", primeList)}");


        }
    }
}
