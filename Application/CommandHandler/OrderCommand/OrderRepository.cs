using Application.ApplicationServices;
using Domain;
using Domain.Entities;
using System;

namespace Application.CommandHandler.OrderCommand
{
    /// <summary>
    /// realizcja interfejsów dla Dependency Injection
    /// </summary>
    public class OrderRepository : IOrder
    {
        private readonly TestAppContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDbContext">relacja (podlaczenie) do bazy danych</param>
        /// <param name="shoppingCart">relacja do koszyka klienta</param>
        public OrderRepository(TestAppContext appDbContext, ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }


        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            _appDbContext.Orders.Add(order);

            var shoppingCartItems = _shoppingCart.CartItems;

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = shoppingCartItem.Quantity,
                    BookId = shoppingCartItem.Book.BookId,
                    //OrderId = order.OrderId,
                    Price = shoppingCartItem.Book.Price
                };

                _appDbContext.OrderDetails.Add(orderDetail);
            }

            _appDbContext.SaveChanges();
        }
    }
}
