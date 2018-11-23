using System;
using System.Collections.Generic;
using System.Text;

namespace _300954759_Kim__300825160_Perroni__Client
{
    public class Genre
    {
        public Genre()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Book> Book { get; set; }
    }
}
