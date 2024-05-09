using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int Published { get; set; }

        public Book(int bookId, string title, string author, string genre, int published)
        {
            BookId = bookId;
            Title = title;
            Author = author;
            Genre = genre;
            Published = published;
        }

        public Book(string title, string author, string genre, int published)
        {
           
            Title = title; 
            Author = author; 
            Genre = genre;
            Published = published;
        }

        public Book() { }
    }
}
