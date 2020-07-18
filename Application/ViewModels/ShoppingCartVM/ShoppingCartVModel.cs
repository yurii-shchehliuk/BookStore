using Domain.Entities;
using System.Collections.Generic;

namespace Application.ViewModels.ShoppingCartVM
{/// <summary>
/// klasa pomocnicza do ustawienia
/// </summary>
    public class ShoppingCartVModel
    {
        public ShoppingCart ShoppingCart { get; set; }
        public decimal ShoppingCartTotal { get; set; }

        //public IEnumerable<Genre> Genre { get; set; }

    }
}
