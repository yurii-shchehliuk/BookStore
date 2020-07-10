using Application.ApplicationServices;
using Domain;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.CommandHandler.BookCommand
{
    public class BookRepository : IBook, ICommandHandler
    {
        private readonly TestAppContext _context;
        public BookRepository(TestAppContext context)
        {
            _context = context;
        }
        public IEnumerable<Book> GetBooks
        {
            get
            {
                return _context.Books.ToList();
            }
        }

        public Book GetBookById(int id) { return _context.Books.FirstOrDefault(c => c.BookId ==id); }
    }
}
