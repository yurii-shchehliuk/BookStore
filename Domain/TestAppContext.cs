using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class TestAppContext : IdentityDbContext<IdentityUser>
    {
        public TestAppContext(DbContextOptions<TestAppContext> options)
           : base(options)
        {

        }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        //public virtual DbSet<BookGenre> BookGenres { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRoles> UsersRoles { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        //public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region relations
            modelBuilder.Entity<User>()
                    .HasOne(a => a.UserRoles)
                    .WithOne(b => b.User).HasForeignKey<UserRoles>(c => c.UserId);
            modelBuilder.Entity<Book>()
                        .HasOne(a => a.Author)
                        .WithOne(b => b.Book).HasForeignKey<Author>(c => c.BookId);

            modelBuilder.Entity<Genre>()
                .HasMany(c => c.Books)
                .WithOne(c => c.Genre);

            //modelBuilder.Entity<Order>()
            //    .HasMany(c => c.CartItems)
            //    .WithOne(c => c.Order);//.HasForeignKey<CartItem>(c=>c.OrderId);
            


            modelBuilder.Entity<CartItem>()
                .HasOne(c => c.Book)
                .WithOne(c => c.CartItem);

            #endregion

            #region identity

            base.OnModelCreating(modelBuilder);
            #endregion
        }
    }
}
