using System.Collections.Generic;
using System.Linq;
using Application.ApplicationServices;
using Application.ViewModels.BookVM;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Web.Controllers
{

    [Route("api/[controller]")]
    public class BookDataController : Controller
    {
        private readonly IBook bookRepos;

        public BookDataController(IBook repos)
        {
            bookRepos = repos;
        }

        [HttpGet]
        public IEnumerable<BookDataVM> LoadMoreBooks()
        {
            IEnumerable<Book> dbBooks = null;

            dbBooks = bookRepos.GetBooks.OrderBy(p => p.BookId).Take(10);

            List<BookDataVM> books = new List<BookDataVM>();

            foreach (var dbBook in dbBooks)
            {
                books.Add(MapDbBookToBookViewModel(dbBook));
            }
            return books;
        }

        private BookDataVM MapDbBookToBookViewModel(Book dbBook) => new BookDataVM()
        {
            
            BookId = dbBook.BookId,
            Title = dbBook.Title,
            Price = dbBook.Price,
            Description = dbBook.Description,
            ImageThumbnailUrl = dbBook.Image
        };

    }
}
