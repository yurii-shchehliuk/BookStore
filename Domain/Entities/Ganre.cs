using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Ganre
    {
        public int GanreId { get; set; }
        public string GanreName { get; set; }
        public virtual ICollection<BookGanre> BookGanres { get; set; }
    }
}
