using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ApplicationServices
{
    public interface IBook : Domain.ICommand
    {
        IEnumerable<Book> GetBooks { get; }
        Book GetBookById(int id);
    }
}
