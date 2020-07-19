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
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        //public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRoles> UsersRoles { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<BasicData1> BasicDatas1 { get; set; }
        public virtual DbSet<BasicData2> BasicDatas2 { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region relations
            modelBuilder.Entity<User>()
                    .HasOne(a => a.UserRoles)
                    .WithOne(b => b.User).HasForeignKey<UserRoles>(c => c.UserId);
            //modelBuilder.Entity<Book>()
            //            .HasOne(a => a.Author)
            //            .WithOne(b => b.Book).HasForeignKey<Author>(c => c.BookId);

            //modelBuilder.Entity<Genre>()
            //    .HasMany(c => c.Books)
            //    .WithOne(c => c.Genre);


            //modelBuilder.Entity<BookCart>().HasKey(sc => new { sc.BookId, sc.CartId });
            //modelBuilder.Entity<BookCart>()
            //       .HasKey(bc => new { bc.BookId, bc.CartId });
            //modelBuilder.Entity<BookCart>()
            //    .HasOne(bc => bc.Book)
            //    .WithMany(b => b.BookCarts)
            //    .HasForeignKey(bc => bc.BookId);
            //modelBuilder.Entity<BookCart>()
            //    .HasOne(bc => bc.CartItem)
            //    .WithMany(c => c.BookCarts)
            //    .HasForeignKey(bc => bc.CartId);


            //modelBuilder.Entity<Order>()
            //    .HasMany(c => c.CartItems)
            //    .WithOne(c => c.Order);//.HasForeignKey<CartItem>(c=>c.OrderId);



            ////modelBuilder.Entity<CartItem>()
            ////    .HasOne(c => c.Book)
            ////    .WithOne(c => c.CartItem);

            #endregion

            #region identity

            base.OnModelCreating(modelBuilder);
            #endregion
        }
    }
}
