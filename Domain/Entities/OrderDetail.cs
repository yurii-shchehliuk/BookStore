namespace Domain.Entities
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int Amount { get; set; }
        public float Price { get; set; }
        //public Nullable<int> OrderId { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        //public virtual Order Order { get; set; }
    }
}
