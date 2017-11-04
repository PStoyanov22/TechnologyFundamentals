using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01.Extract_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var pattern = @"\b(?<!\-|\.|\:|_)([a-z.-0-9]+@[a-zA-Z-]+)(\.[a-zA-Z]+)+\b";

            var regex = new Regex(pattern);

            var matches = regex.Matches(input);

            foreach (var email in matches)
            {
              
                Console.WriteLine(email);
            }
        }
    }
}
