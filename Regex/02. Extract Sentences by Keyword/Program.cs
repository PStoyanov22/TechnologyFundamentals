using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.Extract_Sentences_by_Keyword
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string[] input = Console.ReadLine()
                .Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            var pattern = @"\b" + word + "\\b"; // "\\b" + word + "\\b";
            var regex = new Regex(pattern);
            foreach (var sentence in input)
            {
                
                if (regex.IsMatch(sentence))
                {
                    Console.WriteLine(sentence.Trim());
                }
               
            }

        }
    }
}
