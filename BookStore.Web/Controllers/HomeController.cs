using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BookStore.Models;
using Application.ViewModels.HomeVM;
using Application.ApplicationServices;
using System.Collections.Generic;
using Domain.Entities;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBook _book;
        private readonly IGenre _genre;
        public HomeIndexVM homeViewModel;

        public HomeController(ILogger<HomeController> logger, IBook book, IGenre genre)
        {
            _logger = logger;
            _book = book;
            _genre = genre;

        }
        public IActionResult Index()
        {
            homeViewModel = new HomeIndexVM();
            var temp = _book.GetBooks.ToList();
            if (temp.Count > 5)
            {
                homeViewModel.FirstSlider = temp.Take(5).ToList();
            }
            else
            {
                homeViewModel.FirstSlider = temp.ToList();

            }
            homeViewModel.NewBooks = _book.GetBooks.Where(c => c.IsThisNew == true).ToList();
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
            homeViewModel = new HomeIndexVM();

            homeViewModel.Promotions = _book.GetBooks.Take(12).ToList();
            return View(homeViewModel);
        }
        public IActionResult Cart()
        {
            return View();
        }
        public ViewResult List(int genreId)
        {
            List<string> _genres = new List<string>(); ;
            IEnumerable<Book> books;
            string currentGenre = string.Empty;


            var genre = _genre.GenreByCategory(genreId); ;
            if (genreId != 0)
            {
                books = _book.GetBooksByGenre(genre.GenreId).OrderBy(p => p.Title).ToList();
            currentGenre = genre.GenreName;
            }
            else
            {
                books = _book.GetBooks.ToList();
            currentGenre = "All books";
            }

            return View(new HomeIndexVM
            {
                Books = books,
                CurrentGenre = currentGenre
            });
        }
        /// <summary>
        /// metoda do wyszukiwania
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public ViewResult Search(string searchString)
        {
            string _searchString = searchString;
            IEnumerable<Book> books;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(_searchString))
            {
                books = _book.GetBooks.OrderBy(p => p.BookId).ToList(); ;
            }
            else
            {
                books = _book.GetBooks.Where(p => p.Title.ToLower().Contains(_searchString.ToLower())).ToList();
            }

            return View("~/Views/Book/List.cshtml", new HomeIndexVM { Books = books, CurrentGenre = "All books" });
        }

        public ViewResult Details(int bookId)
        {
            var book = _book.GetBooks.FirstOrDefault(d => d.BookId == bookId);
            if (book == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            return View(book);
        }
    }
}
