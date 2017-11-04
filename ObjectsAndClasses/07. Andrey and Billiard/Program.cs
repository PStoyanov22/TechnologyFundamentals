using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _07.Andrey_and_Billiard
{
    class Program
    {
        class Student
        {
            public string Name { get; set; }

            public Dictionary<string, int> ShopList { get; set; }

            public decimal Bill { get; set; }
        }


        static void Main(string[] args)
        {


            var productAndPrice = new Dictionary<string, decimal>();

            GetProductPrices(productAndPrice);

            string order = Console.ReadLine();
            var customers = new List<Student>();


            while (order != "end of clients")
            {
                var list = order
                    .Split(new char[] { '-', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                bool hasAlreadyPurchased = false;
                var customerName = list[0];
                var product = list[1];
                var productQuantity = int.Parse(list[2]);

                var shoppingList = new Dictionary<string, int> { { product, productQuantity } };

                if (productAndPrice.ContainsKey(product))
                {

                    foreach (var customer in customers)
                    {
                        if (customer.Name == customerName)
                        {
                            hasAlreadyPurchased = true;
                            if (customer.ShopList.ContainsKey(product))
                            {
                                customer.ShopList[product] += productQuantity;
                            }
                            else
                            {
                                customer.ShopList.Add(product, productQuantity);
                            }
                            break;
                        }
                    }
                    
                    if (hasAlreadyPurchased == false)
                    {
                        var student = new Student
                        {
                            Name = customerName,
                            ShopList = shoppingList
                        };
                        customers.Add(student);
                    }
                }

                order = Console.ReadLine();

            }

            var clients = customers
                              .Distinct()
                              .OrderBy(c => c.Name).ToList();

            foreach (Student client in clients)
            {

                foreach (var product in client.ShopList)
                {
                    foreach (var item in productAndPrice)
                    {
                        if (product.Key == item.Key)
                        {
                            client.Bill += product.Value * item.Value;
                        }
                    }
                }
            }


            foreach (var client in clients)
            {
                Console.WriteLine(client.Name);
                foreach (var item in client.ShopList)
                {
                    Console.WriteLine($"-- {item.Key} - {item.Value}");

                }
                Console.WriteLine($"Bill: {client.Bill:f2}");
            }
            Console.WriteLine($"Total bill: {customers.Sum(s => s.Bill):f2}");


        }

        private static void GetProductPrices(Dictionary<string, decimal> productAndPrice)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();


                if (!productAndPrice.ContainsKey(input[0]))
                {
                    productAndPrice.Add(input[0], decimal.Parse(input[1]));
                }
                productAndPrice[input[0]] = decimal.Parse(input[1]);

            }
        }
    }
}
