using Application.ApplicationServices;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BookStore.Web.Components
{
    /// <summary>
    /// klasa pomocnicza do wyswietlania oraz
    /// </summary>
    public class GenresMenu:ViewComponent
    {
        private readonly IGenre _genreRepos;
        /// <summary>
        /// konstrukor dla dependency injection
        /// </summary>
        /// <param name="genreRepos"></param>
        public GenresMenu(IGenre genreRepos)
        {
            _genreRepos = genreRepos;
        }
        /// <summary>
        /// metoda do pobierania oraz przekazania gatunków do strony
        /// </summary>
        /// <returns>zwraca gatunki</returns>

        public IViewComponentResult Invoke()
        {
            var genre = _genreRepos.Genres.OrderBy(p => p.GenreName);
            return View("Genres", genre);
        }
    }
}
