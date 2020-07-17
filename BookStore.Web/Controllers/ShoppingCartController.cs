using System.Linq;
using Application.ApplicationServices;
using Application.ViewModels.ShoppingCartVM;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
       
        private readonly IBook _bookRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IBook bookRepository, ShoppingCart shoppingCart)
        {
            _bookRepository = bookRepository;
            _shoppingCart = shoppingCart;
        }

        [Authorize]
        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.CartItems = items;

            var shoppingCartViewModel = new ShoppingCartVModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(shoppingCartViewModel);
        }

        [Authorize]
        public RedirectToActionResult AddToShoppingCart(int bookId)
        {
            var selectedBook = _bookRepository.GetBooks.FirstOrDefault(p => p.BookId == bookId);
            if (selectedBook != null)
            {
                _shoppingCart.AddToCart(selectedBook, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int bookId)
        {
            var selectedBook = _bookRepository.GetBooks.FirstOrDefault(p => p.BookId== bookId);
            if (selectedBook != null)
            {
                _shoppingCart.RemoveFromCart(selectedBook);
            }
            return RedirectToAction("Index");
        }
    }
}
