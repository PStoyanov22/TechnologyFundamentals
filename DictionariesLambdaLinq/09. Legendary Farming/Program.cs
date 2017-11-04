using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {


            SortedDictionary<string, int> keyMaterials =
                new SortedDictionary<string, int>()
                {
                    { "motes", 0 },
                    { "shards", 0},
                    { "fragments", 0}

                };
        SortedDictionary<string, int> junk = new SortedDictionary<string, int>();

        string material = "";
        int quantity = 0;

        bool legendaryObtained = false;

            while (legendaryObtained == false)
            {
               List<string> input = Console.ReadLine().ToLower()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();



                for (int i = 0; i  <input.Count; i += 2)
                {
                    quantity = int.Parse(input[i]);

                    material = input[i + 1];


                    if (material == "motes" || material == "shards"
                                            || material == "fragments")
                    {
                        if (!keyMaterials.ContainsKey(material))
                        {
                            keyMaterials.Add(material, quantity);
                        }
                        else
                        {
                            keyMaterials[material] += quantity;
                        }

                        if (keyMaterials["motes"] >= 250)
                        {
                            

                            legendaryObtained = true;
                            Console.WriteLine("Dragonwrath obtained!");
                            keyMaterials[material] -= 250;
                            break;
                        }
                        if (keyMaterials["shards"] >= 250)
                        {


                            legendaryObtained = true;
                            Console.WriteLine("Shadowmourne obtained!");
                            keyMaterials[material] -= 250;
                            break;
                        }
                        if (keyMaterials["fragments"] >= 250)
                        {


                            legendaryObtained = true;
                            Console.WriteLine("Valanyr obtained!");
                            keyMaterials[material] -= 250;
                            break;
                        }


                    }
                    else
                    {
                        if (!junk.ContainsKey(material))
                        {
                            junk.Add(material, quantity);
                        }
                        else
                        {
                            junk[material] += quantity;
                        }
                    }
                }
            }

            foreach (var item in keyMaterials.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine(string.Join(": ", item.Key, item.Value));

            }
            foreach (var item in junk)
            {
                Console.WriteLine(string.Join(": ", item.Key, item.Value));
            }


        }
    }
}
