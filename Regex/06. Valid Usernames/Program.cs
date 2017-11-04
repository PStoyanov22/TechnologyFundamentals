using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace _06.Valid_Usernames
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine()
                .Split(new char[] { ' ', '/', '\\', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);

            var pattern = @"\b([A-Za-z]{1}\w{2,24})";
            string text = string.Join(" ", input);

            var valid = new List<string>();
            var matches = new Regex(pattern);
            var username = Regex.Matches(text, pattern);

            foreach (Match user in username)
            {

                if (!valid.Contains(user.Value))
                {
                    valid.Add(user.Value);
                }
                
            }

            var maxLength = 0;
            var length = 0;
            var firstFromCouple = "";
            var secondFromCouple = "";
            if (valid.Count == 0)
            {
                Console.WriteLine("no");
            }
            for (int i = 0; i < valid.Count; i++)
            {
                
                if (i == (valid.Count-1))
                {
                    length = valid[i].Length + valid[i - 1].Length;
                    if (length > maxLength)
                    {
                        maxLength = length;
                        firstFromCouple = valid[i - 1];
                        secondFromCouple = valid[i];

                    }

                }
                else
                {
                    length = valid[i].Length + valid[i + 1].Length;
                    if (length > maxLength)
                    {
                        maxLength = length;
                        firstFromCouple = valid[i];
                        secondFromCouple = valid[i + 1];

                    }
                }
                
                i++;
            }
            Console.WriteLine(firstFromCouple);
            Console.WriteLine(secondFromCouple);

         
            
        }
    }
}
