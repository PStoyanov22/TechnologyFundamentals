using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace _06.Book_Library_Modification
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
        public DateTime ReleaseDate { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
    }
    
    class BookLibraryModification
    {
        static void Main()
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
                    ReleaseDate = DateTime.ParseExact(input[3], "dd.MM.yyyy", CultureInfo.InvariantCulture),
                   
                };
               

                books.Add(book);

            }
            var givenDate = Console.ReadLine();
            DateTime date = DateTime.ParseExact(givenDate, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            

            foreach (var book in books.OrderBy(d => d.ReleaseDate).ThenBy(a => a.Title))
            {
                if (book.ReleaseDate > date)
                {
                    Console.WriteLine($"{book.Title} -> {book.ReleaseDate.ToString("dd.MM.yyyy")}");
                }
            }
        }
    }
}
