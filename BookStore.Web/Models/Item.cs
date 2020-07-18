using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Web.Models
{
    public class Item
    {
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
