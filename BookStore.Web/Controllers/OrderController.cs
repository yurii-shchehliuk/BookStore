﻿using Application.ApplicationServices;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrder _orderRepository;
        private readonly ShoppingCart _shoppingCart;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderRepository"></param>
        /// <param name="shoppingCart"></param>
        public OrderController(IOrder orderRepository, ShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }

        [Authorize]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Checkout(Order order)
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.CartItems = items;
            if (_shoppingCart.CartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your card is empty, add some books first");
            }

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }

            return View(order);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order! :) ";
            return View();
        }
        public IActionResult BasicData1()
        {
            return View();
        } public IActionResult BasicData2()
        {
            return View();
        }
    }
}