using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace _03.Camera_View
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            string text = Console.ReadLine();

            var pattern = @"(?<=\|<)\b([^_])[a-zA-z]+\b(?<!_)";

         
            var regex = new Regex(pattern);

            var matches = regex.Matches(text);
            
            for (int i = 0; i < matches.Count; i++)
            {
                var matchTostring = matches[i].ToString().Skip(array[0]).Take(array[1]);
              
                var word = string.Join("", matchTostring);

                if (i < matches.Count - 1)
                {
                    Console.Write($"{word}, ");
                }
                else
                {
                    Console.WriteLine(word);
                }
                
            }
        }
    }
}
