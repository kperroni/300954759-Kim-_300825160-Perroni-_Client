using System;
using System.Collections.Generic;
using System.Text;

namespace _300954759_Kim__300825160_Perroni__Client
{
    public class Bookshelf
    {
        public int Id { get; set; }
        public int ShelfId { get; set; }
        public int BookId { get; set; }

        public Book Book { get; set; }
        public Shelf Shelf { get; set; }
    }
}
