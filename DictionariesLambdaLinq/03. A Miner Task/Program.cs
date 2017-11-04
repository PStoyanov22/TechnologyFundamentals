using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, int> resources = new Dictionary<string, int>();

            bool canContinue = true;

            while (canContinue)
            {
                string input = Console.ReadLine();

                int quantity;

                if (input == "stop")
                {
                    canContinue = false;
                    break;
                }
                else
                {
                     quantity = int.Parse(Console.ReadLine());
                }
                
                if (!resources.ContainsKey(input))
                {
                    resources.Add(input, quantity);
                    canContinue = true;
                }
                else
                {
                    resources[input] += quantity;
                    canContinue = true;
                }
            }

            foreach (var element in resources)
            {
                Console.WriteLine("{0} -> {1}", element.Key, element.Value);
            }
        }
    }
}
