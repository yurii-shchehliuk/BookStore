﻿using Application.ApplicationServices;
using Domain;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Application.CommandHandler.GenreCommand
{/// <summary>
/// realizcja interfejsów dla Dependency Injection
/// </summary>
    public class GenreRepository : IGenre,ICommandHandler
    {/// <summary>
    /// dependency injection field dla bazy danych
    /// </summary>
        private readonly AppDbContext _appDbContext;
        public GenreRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Genre> Genres
        {
            get
            {
                var temp = _appDbContext.Genres.ToList();
                return temp;
            }
        }
        public Genre GenreByCategory(int genreId)
        {
           
           return _appDbContext.Genres.FirstOrDefault(c => c.GenreId == genreId);
            
        }
    }
}
