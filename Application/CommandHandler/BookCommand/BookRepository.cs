﻿using Application.ApplicationServices;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.CommandHandler.BookCommand
{/// <summary>
/// realizcja interfejsów dla Dependency Injection
/// </summary>
    public class BookRepository : IBook, ICommandHandler
    {
        private readonly AppDbContext _context;
        /// <summary>
        /// konstruktor
        /// </summary>
        /// <param name="context"></param>
        public BookRepository(AppDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// realizacja metody GetBooks z interfejsu
        /// </summary>
        public IEnumerable<Book> GetBooks
        {
            get
            {
                return _context.Books.ToList();
            }
        }
        public async Task<IEnumerable<Book>> GetListOfBooks()
        {
            return await _context.Books.ToListAsync();
        }
        public IEnumerable<Book> GetBooksByGenre(int genreId)
        {
            var genre= _context.Genres.FirstOrDefault(c => c.GenreId == genreId);

            return _context.Books.Where(c => c.Genre == genre);
        }

        /// <summary>
        /// realizacja metody z interfejsu
        /// </summary>
        /// <param name="id">identyfikator konkrentnej ksiazki</param>
        /// <returns></returns>
        public Book GetBookById(int id) { return _context.Books.FirstOrDefault(c => c.BookId ==id); }
    }
}
