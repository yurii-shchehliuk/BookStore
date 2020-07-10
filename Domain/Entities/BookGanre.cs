using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class BookGanre
    {
        public int BookId { get; set; }
        public int GanreId { get; set; }
        public Book Book { get; set; }
        public virtual Ganre Ganre { get; set; }
    }
}
