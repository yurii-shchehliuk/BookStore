using Domain.Entities;
using System.Collections.Generic;

namespace Application.ViewModels.BookVM
{
    public class BookViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public string CurrentGenre { get; set; }
    }
}
