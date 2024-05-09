using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace Client
{
    public class Menu
    {
        private readonly HttpRequestSender sender = new HttpRequestSender();

        public void Run()
        {
            while (true)
            {
                PrintAllBooks();

                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Add book");
                Console.WriteLine("2. Edit book");
                Console.WriteLine("3. Remove book");
                Console.WriteLine("4. Leave application");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddNewBook();
                        break;
                    case "2":
                        EditBook();
                        break;
                    case "3":
                        RemoveBook();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye");
                        return;
                    default:
                        Console.WriteLine("Not an option.");
                        break;
                }
            }
        }

        private void PrintAllBooks()
        {
            List<Book> books = sender.GetAllBooks();
            if (books == null)
            {
                Console.WriteLine("Something went wrong!");
            }
            else
            {
                foreach (Book book in books)
                {
                    Console.WriteLine($"Id: {book.BookId}, Title: {book.Title}, Author: {book.Author}, Published: {book.Published}, Genre: {book.Genre}");
                }
            }
        }

        private void AddNewBook()
        {
            Console.WriteLine("Input book title.");
            string title = Console.ReadLine();
            Console.WriteLine("Input book author.");
            string author = Console.ReadLine();
            Console.WriteLine("Input book genre");
            string genre = Console.ReadLine();
            Console.WriteLine("Input when book was published.");
            if (int.TryParse(Console.ReadLine(), out int published))
            {
                sender.AddBook(title, author, genre, published);
            }
            else
            {
                Console.WriteLine("That was not a number.");
            }
        }

        private void EditBook()
        {
            Console.WriteLine("Input the id of the book you want to edit.");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Input new book title.");
                string title = Console.ReadLine();
                Console.WriteLine("Input new author.");
                string author = Console.ReadLine();
                Console.WriteLine("Input new book genre.");
                string genre = Console.ReadLine();
                Console.WriteLine("Input new published year.");
                if (int.TryParse(Console.ReadLine(), out int published))
                {
                    sender.EditBook(id, title, author, genre, published);
                }
                else
                {
                    Console.WriteLine("That was not a number.");
                }
            }
            else
            {
                Console.WriteLine("That was not a number");
            }
        }

        private void RemoveBook()
        {
            Console.WriteLine("Input the id of the book you want to delete.");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                sender.DeleteBook(id);
            }
            else
            {
                Console.WriteLine("That was not a number.");
            }
        }
    }
}