using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Dragon_Army
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<double>>> dragons =
                  new Dictionary<string, Dictionary<string, List<double>>>();

            double n = double.Parse(Console.ReadLine());

            List<Dragon> dragonss = new List<Dragon>();

            for (double i = 0; i < n; i++)
            {
                string[] commandArgs = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                Dragon dragon = CreateDragon(commandArgs);

                if (!dragonss.Any(d => d.Name == dragon.Name && d.Type == dragon.Type))
                {
                    dragonss.Add(CreateDragon(commandArgs));
                }
                else
                {
                    var rem = dragonss.FirstOrDefault(d => d.Name == dragon.Name && d.Type == dragon.Type);

                    if (commandArgs[2] != "null")
                    {
                        rem.Damage = double.Parse(commandArgs[2]);
                    }
                    else
                    {
                        rem.Damage = 45;
                    }
                    if (commandArgs[3] != "null")
                    {
                        rem.Health = double.Parse(commandArgs[3]);
                    }
                    else
                    {
                        rem.Health = 250;
                    }
                    if (commandArgs[4] != "null")
                    {
                        rem.Armor = double.Parse(commandArgs[4]);
                    }
                    else
                    {
                        rem.Armor = 10;
                    }
                }

            }
            foreach (string typee in dragonss.Select(d => d.Type).Distinct())
            {
                var averageDamage = dragonss
                    .Where(d => d.Type == typee)
                    .Average(d => d.Damage);
               
                var averageHealth = dragonss
                    .Where(d => d.Type == typee)
                    .Average(d => d.Health);

                var averageArmor = dragonss
                    .Where(d => d.Type == typee)
                    .Average(d => d.Armor);       
                
                Console.WriteLine($"{typee}::({averageDamage:f2}/{averageHealth:f2}/{averageArmor:f2})");
                  

                foreach (var dragon in dragonss.Where(d => d.Type == typee).OrderBy(e => e.Name))
                {
                    Console.WriteLine($"-{dragon.Name} -> damage: {dragon.Damage}," +
                        $" health: {dragon.Health}, armor: {dragon.Armor}");
                } 
            }
            
        }

        public static Dragon CreateDragon(string[] commandArgs)
        {
            Dragon dragon = new Dragon();
            dragon.Type = commandArgs[0];
            dragon.Name = commandArgs[1];
            if (commandArgs[2] != "null")
            {
                dragon.Damage = double.Parse(commandArgs[2]);
            }
            else
            {
                dragon.Damage = 45;
            }
            if (commandArgs[3] != "null")
            {
                dragon.Health = double.Parse(commandArgs[3]);
            }
            else
            {
                dragon.Health = 250;
            }
            if (commandArgs[4] != "null")
            {
                dragon.Armor = double.Parse(commandArgs[4]);
            }
            else
            {
                dragon.Armor = 10;
            }
            return dragon;
        }
                
    }

    public class Dragon
    {
        public string Type { get; set; }

        public string Name { get; set; }

        public double Damage { get; set; }

        public double Health { get; set; }

        public double Armor { get; set; }
    }
}
