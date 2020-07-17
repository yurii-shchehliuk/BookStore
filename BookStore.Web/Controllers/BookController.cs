using System;
using System.Collections.Generic;
using System.Linq;
using Application.ApplicationServices;
using Application.ViewModels.BookVM;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IBook _bookRepository;
        private readonly IGenre _genreRepository;
        /// <summary>
        /// konstriktor
        /// </summary>
        /// <param name="bookRepository"></param>
        /// <param name="GenreRepository"></param>
        public BookController(IBook bookRepository, IGenre GenreRepository)
        {
            _bookRepository = bookRepository;
            _genreRepository = GenreRepository;
        }
        /// <summary>
        /// wyswietla wszystkie ksiazki
        /// </summary>
        /// <param name="genreId"></param>
        /// <returns></returns>
        public ViewResult List(int genreId)
        {
            List<string> _genres = new List<string>(); ;
            IEnumerable<Book> books;
            string currentGanre = string.Empty;


            var genre = _genreRepository.GenreByCategory(genreId); ;
            if (genreId != 0)
            {
                books = _bookRepository.GetBooksByGenre(genre.GenreId).OrderBy(p => p.Title);
            }
            else
            {
                books = _bookRepository.GetBooks.ToList();
            }

            currentGanre = genre.GenreName;


            return View(new BookViewModel
            {
                Books = books,
                CurrentGanre = currentGanre
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
                books = _bookRepository.GetBooks.OrderBy(p => p.BookId).ToList(); ;
            }
            else
            {
                books = _bookRepository.GetBooks.Where(p => p.Title.ToLower().Contains(_searchString.ToLower())).ToList();
            }

            return View("~/Views/Book/List.cshtml", new BookViewModel { Books = books, CurrentGanre = "All books" });
        }

        public ViewResult Details(int bookId)
        {
            var book = _bookRepository.GetBooks.FirstOrDefault(d => d.BookId == bookId);
            if (book == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            return View(book);
        }
    }
}
