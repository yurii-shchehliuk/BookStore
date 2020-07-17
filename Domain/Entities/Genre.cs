using System.Collections.Generic;

namespace Domain.Entities
{/// <summary>
/// typ książki
/// </summary>
    public class Genre
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public virtual List<Book> Books { get; set; }
    }
}
