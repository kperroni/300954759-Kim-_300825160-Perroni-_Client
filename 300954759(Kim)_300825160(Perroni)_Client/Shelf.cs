using System;
using System.Collections.Generic;
using System.Text;

namespace _300954759_Kim__300825160_Perroni__Client
{
    public class Shelf
    {
        public Shelf()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public ICollection<Bookshelf> Bookshelf { get; set; }
    }
}
