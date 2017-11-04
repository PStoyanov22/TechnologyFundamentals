using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Index_of_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine().ToLower();

            char[] array = word.ToCharArray();

            
            for (int i = 0; i < array.Length; i++)
            {

                int character = Convert.ToInt32(array[i]);
                Console.WriteLine($"{array[i]} -> {character - 97}");
            }
        }
    }
}
