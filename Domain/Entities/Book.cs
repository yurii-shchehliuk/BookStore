using System.Collections.Generic;

namespace Domain.Entities
{
    /// <summary>
    /// Representuje ksiażkę pod bazą
    /// </summary>
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }
        public int Discount { get; set; }
        public float PriceAfterDiscount { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool IsThisNew { get; set; }

        public virtual Author Author { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual CartItem CartItem { get; set; }
        //public virtual ICollection<BookCart> BookCarts { get; set; }

    }
}
