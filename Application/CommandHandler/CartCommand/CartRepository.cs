using Application.ApplicationServices;
using Domain;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.CommandHandler.CartCommand
{
    public class CartRepository:ICart, ICommandHandler
    {
        private readonly TestAppContext _context;
        public CartRepository(TestAppContext context)
        {
            _context = context;
        }
        public void AddToCart(Book book, int amount)
        {
            var shoppingCart = _context.CartItems.SingleOrDefault(c=>c.Book.BookId==book.BookId&&c.CartItemId==book.CartItem.CartItemId);
            if (shoppingCart==null)
            {
                shoppingCart = new CartItem
                {
                    Book = book,
                    Amount=1
                };
                _context.CartItems.Add(shoppingCart);
            }
            else
            {
                shoppingCart.Amount++;
            }
        }
    }
}
