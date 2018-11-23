using System;
using System.Collections.Generic;
using System.Text;

namespace _300954759_Kim__300825160_Perroni__Client
{
    public class Book
    {
        public Book()
        {

        }

        public int Id { get; set; }
        public string Title { get; set; }
        public String PublicationDate { get; set; }
        public string Publisher { get; set; }
        public int NumOfPages { get; set; }
        public int GenreId { get; set; }
        public int AuthorId { get; set; }

        public Author Author { get; set; }
        public Genre Genre { get; set; }
        public ICollection<Bookshelf> Bookshelf { get; set; }
    }
}
