namespace Application.DTO.BookDTO
{
    public class BookOrder
    {
        public BookOrder(int userId,int bookId,string title, float price, int discount, int quantity)
        {
            this.UserId = userId;
            this.BookId = bookId;
            this.Title = title;
            this.Price = price;
            this.Discount = discount;
            this.Quantity = quantity;
        }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }
        public int Discount { get; set; }
        public int Quantity { get; set; }
    }
}
