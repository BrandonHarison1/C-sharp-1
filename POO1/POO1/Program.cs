using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO1
{
    public class Book
    {
        public string Title { get; set; }
        public bool IsRead { get; set; }


        public bool isBookRead(Book[] books, string titleToSearch)
        {
            foreach (Book book in books)
            {
                if (book.Title == titleToSearch)
                {
                    return book.IsRead;
                }
            }
            return false;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
        var books = new Book[] {
        new Book
        {
            Title = "Harry Potter y la piedra filosofal",
            IsRead = true
        },
        new Book
        {
            Title = "Canción de hielo y fuego",
            IsRead = false
        },
        new Book
        {
             Title = "Devastación",
             IsRead = true
        },
        };

            
        Console.WriteLine(books[0].isBookRead(books, "Devastación")); // true
        Console.WriteLine(books[0].isBookRead(books, "Canción de hielo y fuego")); // false
        Console.WriteLine(books[0].isBookRead(books, "Los Pilares de la Tierra")); // false
        Console.WriteLine(books[0].isBookRead(books, "Nombre inventado")); // false
        Console.ReadLine();
        }
    }
}
