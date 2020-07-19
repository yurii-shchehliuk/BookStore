using System.Collections.Generic;

namespace Domain.Entities
{/// <summary>
/// autor ksiażki
/// </summary>
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Bio { get; set; }
        public virtual List<Book> Book { get; set; }
    }
}
