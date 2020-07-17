using Domain.Entities;
using System.Collections.Generic;

namespace Application.ApplicationServices
{/// <summary>
/// dependency injection interface
/// </summary>
    public interface IGenre : Domain.ICommand
    {
        IEnumerable<Genre> Genres { get; }
        Genre GenreByCategory(int ganreId);

    }
}
