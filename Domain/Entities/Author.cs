namespace Domain.Entities
{/// <summary>
/// autor ksiażki
/// </summary>
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}
