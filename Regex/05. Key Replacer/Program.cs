using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace _05.Key_Replacer
{
    class Program
    {
        public static void Main()
        {
            string keyText = Console.ReadLine();

            var startPattern = @"^([A-Za-z]+)(?=\||\<|\\)";
            var endPattern = @"(?<=\<|\||\\)([A-Za-z]+)(?!.)";

            var startRegex = Regex.Match(keyText, startPattern);
            string firstWord = startRegex.Groups[1].Value;            
            
           
            var endRegex = Regex.Match(keyText, endPattern);
            string secondWord = endRegex.Groups[1].Value;
           
            string text = Console.ReadLine();

            var finalPattern = @"(" + firstWord + "(.*?)" + secondWord + ")";

            var matches = Regex.Matches(text, finalPattern);

            if (matches.Count > 0)
            {
                foreach (Match item in matches)
                {
                    Console.Write(item.Groups[2].Value);
                }
            }
            else
            {
                Console.WriteLine("Empty result");
            }
            



                // @"(?<="startRegex")" + .*? +"(?="endRegex")";
        }
    }
}
