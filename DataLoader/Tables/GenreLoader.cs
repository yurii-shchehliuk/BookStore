using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLoader.Tables
{
    public class GenreLoader
    {
        public int genresCount=0;
        private readonly TestAppContext _context;
        public GenreLoader(TestAppContext testAppContext)
        {
            _context = testAppContext;
            genresCount = testAppContext.Genres.Count();
        }
        public void LoadMethod()
        {

        }
    }
}
