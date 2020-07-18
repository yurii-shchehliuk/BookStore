using Domain;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace BookStore.Web.Models
{
    public class CartModel
    {
        private readonly TestAppContext _context;
        public CartModel(TestAppContext context)
        {
            _context = context;
        }
        public List<Item> MyCart;
        public void OnGet()
        {
            MyCart = SessionHelper.GetFromJson<List<Item>>(HttpContext.Session, "cart");

        }
        public void OnGetBuy(string id)
        {
            var book = _context.Books.Find(id);
            List<Item> cart = SessionHelper.GetFromJson<List<Item>>(HttpContext.Session, "cart");
            if (cart == null)
            {
                cart = new List<Item>();
                cart.Add(new Item()
                {
                    Book = book,
                    Quantity = 1
                });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                var index = Exist(cart, id);
                if (index == -1)
                {
                    cart.Add(new Item()
                    {
                        Book = book,
                        Quantity = 1
                    });

                }
                else
                {

                    var newQuantity = cart[index].Quantity +1;
                    cart[index].Quantity = newQuantity;
                }
            }

        }

        private int Exist(List<Item> cart, string id)
        {
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Book.BookId.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
