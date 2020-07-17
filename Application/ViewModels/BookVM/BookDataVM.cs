namespace Application.ViewModels.BookVM
{
    /// <summary>
    /// DTO model
    /// </summary>
    public class BookDataVM
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string ImageThumbnailUrl { get; set; }
    }
}
