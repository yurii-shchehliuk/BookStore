using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class TestAppContext : DbContext
    {
        public TestAppContext(DbContextOptions<TestAppContext> options)
           : base(options)
        {

        }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookGenre> BookGenres { get; set; }
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


            modelBuilder.Entity<BookGenre>()
                .HasKey(bg => new { bg.BookId, bg.GenreId });
            modelBuilder.Entity<BookGenre>()
                .HasOne(bg => bg.Book)
                .WithMany(b => b.BooksGanres)
                .HasForeignKey(bg => bg.BookId);
            modelBuilder.Entity<BookGenre>()
                .HasOne(bg => bg.Genre)
                .WithMany(g => g.BookGenres)
                .HasForeignKey(bg => bg.GenreId);

            modelBuilder.Entity<CartItem>()
                .HasOne(c => c.Book)
                .WithOne(c => c.CartItem);

            #endregion

            #region
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Image = @"C:\Users\Jerzy\source\repos\TestApplication\BookStore.Web\wwwroot\img\Books\3OVAxVVhAeE.jpg",
                    Price = 50,
                    Discount = 0,
                    Quantity = 14
                }, new Book
                {
                    Image = @"C:\Users\Jerzy\source\repos\TestApplication\BookStore.Web\wwwroot\img\Books\f8sNEYR1GS4.jpg",
                    Price = 40,
                    Discount = 0,
                    Quantity = 14
                }, new Book
                {
                    Image = @"C:\Users\Jerzy\source\repos\TestApplication\BookStore.Web\wwwroot\img\Books\fB4Cro5nwCg.jpg",
                    Price = 60,
                    Discount = 0,
                    Quantity = 14
                }, new Book
                {
                    Image = @"C:\Users\Jerzy\source\repos\TestApplication\BookStore.Web\wwwroot\img\Books\HdbMcallbt0.jpg",
                    Price = 60,
                    Discount = 0,
                    Quantity = 14
                }, new Book
                {
                    Image = @"C:\Users\Jerzy\source\repos\TestApplication\BookStore.Web\wwwroot\img\Books\HVJ4YAWOApk.jpg",
                    Price = 14,
                    Discount = 0,
                    Quantity = 14
                }

                );
            #endregion
        }
    }
}
