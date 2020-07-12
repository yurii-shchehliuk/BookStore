using Domain.Entities;
using System.Collections.Generic;

namespace Application.ApplicationServices
{
    /// <summary>
    /// dependency injection interface
    /// </summary>
    public interface IBook : Domain.ICommand
    {
        IEnumerable<Book> GetBooks { get; }
        Book GetBookById(int id);
    }
}
