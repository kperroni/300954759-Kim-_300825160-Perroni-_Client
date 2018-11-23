using System;
using System.Collections.Generic;
using System.Text;

namespace _300954759_Kim__300825160_Perroni__Client
{
    public class User
    {
        public User()
        {
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public ICollection<Shelf> Shelf { get; set; }
    }
}
