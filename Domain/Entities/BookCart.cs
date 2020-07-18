using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class BookCart
    {
        public int BookId { get; set; }
        public int CartId { get; set; }
        public virtual Book Book { get; set; }
        public virtual CartItem CartItem { get; set; }
    }
}
