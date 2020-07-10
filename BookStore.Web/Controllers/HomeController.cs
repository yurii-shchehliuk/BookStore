using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BookStore.Models;
using Application.ViewModels.HomeVM;
using Domain;
using Application.ApplicationServices;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBook _book;

        public HomeController(ILogger<HomeController> logger, IBook book)
        {
            _logger = logger;
            _book = book;

        }

        public IActionResult Index()
        {
            HomeIndexVM homeViewModel = new HomeIndexVM();
            homeViewModel.FirstSlider = _book.GetBooks.Take(3).ToList();
            homeViewModel.Books = _book.GetBooks.ToList();
            return View(homeViewModel);
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Promotions()
        {
            return View();
        }
        public IActionResult Cart()
        {
            return View();
        }
    }
}
