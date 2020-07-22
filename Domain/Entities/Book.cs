using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    /// <summary>
    /// Representuje ksiażkę pod bazą
    /// </summary>
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }
        public int Discount { get; set; }
        public float PriceAfterDiscount { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool IsThisNew { get; set; }
        public int InStock { get; set; }

        //relacje z innymi tabelkami z poziomu kodu
        public Nullable<int> AuthorId { get; set; }
        public Nullable<int> GenreId { get; set; }
        public virtual Author Author { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual ICollection<CartItem> CartItem { get; set; }

    }
}
