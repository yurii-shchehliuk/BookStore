using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    /// <summary>
    /// Koszyk zamówienia
    /// </summary>
    public class ShoppingCart
    {
        private readonly TestAppContext _context;
        public ShoppingCart(TestAppContext context)
        {
            _context = context;
        }
        public string ShoppingCartId { get; set; }
        public List<CartItem> CartItems { get; set; }




        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<TestAppContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Book book, int amount)
        {
            var shoppingCartItem =
                    _context.CartItems.SingleOrDefault(
                        s => s.Book.BookId == book.BookId && s.ShoppingCartId == ShoppingCartId);
  
            if (shoppingCartItem == null)
            {
                if (amount > book.InStock)
                {
                }
                shoppingCartItem = new CartItem
                {
                    
                    Discount = book.Discount,
                    Book = book,
                    ShoppingCartId = ShoppingCartId,
                    BookId = book.BookId,
                    Quantity = Math.Min(book.InStock, amount)
                };

                _context.CartItems.Add(shoppingCartItem);
            }
            else
            {
                if (book.InStock - shoppingCartItem.Quantity - amount >= 0)
                {
                    shoppingCartItem.Quantity += amount;
                }
                else
                {
                    shoppingCartItem.Quantity += (book.InStock - shoppingCartItem.Quantity);
                }
            }
            _context.SaveChanges();
        }

        public int RemoveFromCart(Book book)
        {
            var shoppingCartItem =
                    _context.CartItems.SingleOrDefault(
                        s => s.Book.BookId == book.BookId && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Quantity > 1)
                {
                    shoppingCartItem.Quantity--;
                    localAmount = shoppingCartItem.Quantity;
                }
                else
                {
                    _context.CartItems.Remove(shoppingCartItem);
                }
            }

            _context.SaveChanges();

            return localAmount;
        }

        public List<CartItem> GetShoppingCartItems()
        {
            return CartItems ??=
                       _context.CartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                           .Include(s => s.Book)
                           .ToList();
        }

        public void ClearCart()
        {
            var cartItems = _context
                .CartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _context.CartItems.RemoveRange(cartItems);

            _context.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _context.CartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                 .Select(c => c.Book.PriceAfterDiscount * c.Quantity).Sum();
            return (decimal)total;
        }

    }
}
