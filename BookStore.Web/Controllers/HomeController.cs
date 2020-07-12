using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BookStore.Models;
using Application.ViewModels.HomeVM;
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
           var temp= _book.GetBooks.ToList();
            if (temp.Count>5)
            {
                homeViewModel.FirstSlider = temp.Take(5).ToList();
            }
            else
            {
                homeViewModel.FirstSlider = temp.ToList();

            }
            homeViewModel.NewBooks = _book.GetBooks.Where(c=>c.IsThisNew==true).ToList();

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
            HomeIndexVM homeViewModel = new HomeIndexVM();
            homeViewModel.Promotions = _book.GetBooks.Take(12).ToList();
            return View(homeViewModel);
        }
        public IActionResult Cart()
        {
            return View();
        }
    }
}
