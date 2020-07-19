using System;
using System.Collections.Generic;

namespace Domain.Entities
{/// <summary>
/// Single cart item
/// </summary>
    public class CartItem
    {
        public int CartItemId { get; set; }
        public float Discount { get; set; }
        public int Quantity{ get; set; }

        public string ShoppingCartId { get; set; }
        public Nullable<int> OrderId { get; set; }
        public int BookId { get; set; }
        public virtual BasicData1 BasicData { get; set; }
        public virtual Book Book { get; set; }
        public virtual Order Order { get; set; }
    }
}
