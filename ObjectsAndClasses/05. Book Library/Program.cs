using System;
using System.Collections.Generic;
using System.Linq;

using System.Globalization;

namespace _05.Book_Library
{
    class Library
    {
        public string Name { get; set; }

        public List<Book> Books { get; set; }
    }

    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime releaseDate { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            
            List<Book> books = new List<Book>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ');

                var book = new Book
                {
                    Title = input[0],
                    Author = input[1],
                    Publisher = input[2],
                    releaseDate = DateTime.ParseExact(input[3], "dd.MM.yyyy", CultureInfo.InvariantCulture),
                    ISBN = input[4],
                    Price = decimal.Parse(input[input.Length-1])
                };

                books.Add(book);
                
            }

            var authorSales = new Dictionary<string, decimal>();

            foreach (var item in books)
            {
                if (!authorSales.ContainsKey(item.Author))
                {
                    authorSales.Add(item.Author, item.Price);
                }
                else if (authorSales.ContainsKey(item.Author))
                {
                    authorSales[item.Author] += item.Price;
                }
               
               
            }

            foreach (var author in authorSales
                .Distinct()
                .OrderByDescending(p => p.Value)
                .ThenBy(a => a.Key))
            {
                Console.WriteLine($"{author.Key} -> {author.Value:f2}");
            }

            
        }
    }
}
