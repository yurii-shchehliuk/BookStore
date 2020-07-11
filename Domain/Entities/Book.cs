using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }
        public int Discount { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public virtual Author Author { get; set; }
        public virtual CartItem CartItem { get; set; }
        public virtual ICollection<BookGenre> BooksGanres { get; set; }

    }
}
