using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Logs_Aggregator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rotations = int.Parse(Console.ReadLine());

            SortedDictionary<string, Dictionary<string, int>> userLogs =
                new SortedDictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < rotations; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ')
                    .ToArray();

                string user = input[1];
                string iP = input[0];
                int duration = int.Parse(input[2]);

                if (!userLogs.ContainsKey(user))
                {
                    userLogs.Add(user, new Dictionary<string, int>());
                    userLogs[user].Add(iP, duration);
                }
                else if (userLogs.ContainsKey(user))
                {
                    if (!userLogs[user].ContainsKey(iP))
                    {
                        userLogs[user].Add(iP, duration);
                    }
                    else
                    {
                        userLogs[user].Add(iP, duration += duration); 
                        // equals to userLogs[user][iP] += duration;
                        
                    }
                }

            }
            foreach (var username in userLogs)
            {
                Console.Write($"{username.Key}: {username.Value.Values.Sum()} [");
                int counter = 0;
                foreach (var ip in username.Value.OrderBy(x => x.Key))
                {

                    counter++;

                    if (counter == username.Value.Count)
                    {
                        Console.Write(string.Join(" ", ip.Key + ']'));
                    }
                    else
                    {
                        Console.Write(string.Join(" ", ip.Key + ',' + " "));
                    }

                }
                Console.WriteLine();

            }
        }
    }
}
