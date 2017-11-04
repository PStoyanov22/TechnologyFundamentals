using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.User_Logs
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> users = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();

            int count = 0;

            while (input != "end")

            {

                string[] line = input
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

                string username = line[2].Substring(5);
                string iP = line[0].Substring(3);
                
                

                if (!users.ContainsKey(username))
                {
                    users.Add(username, new Dictionary<string, int>());
                    users[username].Add(iP, 1);
                }
                else  
                {
                    if (users[username].ContainsKey(iP))
                    {
                        users[username][iP]++;
                    }

                    else
                    {
                        users[username].Add(iP, 1);
                    }
                                       
                    
                }              
                
                input = Console.ReadLine();
            }

            foreach (var username in users.OrderBy(x => x.Key))
            {
                Console.WriteLine(string.Join(" ", username.Key + ':' + " "));
                int counter = 0;
                foreach (var ip in username.Value)
                {
                                        
                    counter++;

                    if (counter == username.Value.Count)
                    {
                        Console.Write(string.Join(" ", ip.Key + " => " + ip.Value + '.'));
                    }
                    else
                    {
                    }
                    
                }
                Console.WriteLine();
                
            }

          

        }
    }
}
