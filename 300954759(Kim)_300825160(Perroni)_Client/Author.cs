using System;
using System.Collections.Generic;
using System.Text;

namespace _300954759_Kim__300825160_Perroni__Client
{
    public class Author
    {
        public Author()
        {

        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AreaOfInterest { get; set; }

        public virtual ICollection<Book> Book { get; set; }
    }
}

