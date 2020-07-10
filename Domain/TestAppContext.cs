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
        public virtual DbSet<BookGanre> BookGanres { get; set; }
        public virtual DbSet<Ganre> Ganres { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRoles> UsersRoles { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(a => a.UserRoles)
                .WithOne(b => b.User)
                .HasForeignKey<UserRoles>(b => b.UserRolesRef);
            modelBuilder.Entity<Book>()
                .HasOne(a => a.Author)
                .WithOne(b => b.Book)
                .HasForeignKey<Author>(b => b.AuthorRef); 
            modelBuilder.Entity<CartItem>()
                .HasOne(a => a.Book)
                .WithOne(b => b.CartItem)
                .HasForeignKey<Book>(b => b.BookRef);

            modelBuilder.Entity<User>()
                .HasMany(c => c.Orders)
                .WithOne(e => e.User)
                .IsRequired(); 
            modelBuilder.Entity<Order>()
                .HasMany(c => c.CartItem)
                .WithOne(e => e.Order)
                .IsRequired();

            modelBuilder.Entity<BookGanre>()
                .HasKey(bg => new { bg.BookId, bg.GanreId });
            modelBuilder.Entity<BookGanre>()
                .HasOne(bg => bg.Book)
                .WithMany(b => b.BooksGanres)
                .HasForeignKey(bg => bg.BookId);
            modelBuilder.Entity<BookGanre>()
                .HasOne(bg => bg.Ganre)
                .WithMany(g => g.BookGanres)
                .HasForeignKey(bg => bg.GanreId);
        }
    }
}
