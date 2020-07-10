using Application.ApplicationServices;
using Application.DTO.BookDTO;
using Domain;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CommandHandler.OrderCommand
{
    public class OrderRepository : IOrder,ICommandHandler
    {
        private readonly TestAppContext _context;
        public OrderRepository(TestAppContext context)
        {
            _context = context;
        }

        //public Order AddOrder(CartItem cartItem)
        //{
        //    Order order = new Order();
          
        //    order.CartItem.Add(cartItem.CartItemId);
        //    order.Discount = bookOrder.Discount;
        //    order.Quantity = bookOrder.Quantity;
        //    order.UserId = bookOrder.UserId;

        //    _context.Orders.Add(order);
        //    return order;
        //}

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
