using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            var sequence = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine().ToLower();             

            
            
            while (command != "odd" && command != "even")
            {
                var commandArgs = command
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)                    
                    .ToArray();

                if (commandArgs[0] == "delete")
                {
                    sequence.RemoveAll( x => x == int.Parse(commandArgs[1]));
                }
                else if (commandArgs[0] == "insert")
                {
                    sequence.Insert(int.Parse(commandArgs[2]), int.Parse(commandArgs[1]));
                }

                command = Console.ReadLine().ToLower();


            }
            if (command == "odd")
            {
                for (int i = 0; i < sequence.Count; i++)
                {
                    if (sequence[i] %  2 != 0)
                    {
                        Console.Write(sequence[i] + " ");
                    }
                }
            }
            else if (command == "even")
            {
                for (int i = 0; i < sequence.Count; i++)
                {
                    if (sequence[i] % 2 == 0)
                    {
                        Console.Write(sequence[i] + " ");
                    }
                }
            }
        }
    }
}
