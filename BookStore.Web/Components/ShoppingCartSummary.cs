using Application.ApplicationServices;
using Application.ViewModels.ShoppingCartVM;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BookStore.Web.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;
        IGenre _genre;
        /// <summary>
        /// konstruktor
        /// </summary>
        /// <param name="shoppingCart"></param>
        public ShoppingCartSummary(ShoppingCart shoppingCart,IGenre genre)
        {
            _shoppingCart = shoppingCart;
            _genre = genre;
        }
        /// <summary>
        /// metoda do przekazania oraz wyświetlaniadanych 
        /// </summary>
        /// <returns>zwraca dane które odpowiadają logicę w danej metodzie</returns>
        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.CartItems = items;

            var shoppingCartViewModel = new ShoppingCartVModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal(),
                //Genre = _genre.Genres.ToList()

            };
            return View("Default", shoppingCartViewModel);
        }

    }
}
