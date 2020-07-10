using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int AuthorRef { get; set; }
        public Book Book { get; set; }
    }
}
