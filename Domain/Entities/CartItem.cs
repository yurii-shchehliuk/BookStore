using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public float Discount { get; set; }
        public int Amount{ get; set; }
        public int OrderId { get; set; }
        public virtual Book Book { get; set; }
        public virtual Order Order { get; set; }
    }
}
