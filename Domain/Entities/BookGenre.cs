using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class BookGenre
    {
        public int BookId { get; set; }
        public int GenreId { get; set; }
        public Book Book { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
