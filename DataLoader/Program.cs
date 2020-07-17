using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;

namespace DataLoader
{
    class Program
    {
        static void Main(string[] args)
        {


            var optionsBuilder = new DbContextOptionsBuilder<TestAppContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TestApplicationDb;Trusted_Connection=True;MultipleActiveResultSets=true");

            using (var context = new TestAppContext(optionsBuilder.Options))
            {
                Random random = new Random();
                int i = 0;
                foreach (var item in Directory.GetFiles(@"C:\Users\Jerzy\source\repos\TestApplication\BookStore.Web\wwwroot\img\Books"))
                {
                    i++;

                    string pathBook = "/img/Books/" + Path.GetFileName(item);
                    float price = random.Next(10, 70);
                    int discount = random.Next(10, 50);
                    int quantity = random.Next(30, 100);
                    Book book = new Book
                    {
                        //BookId = i,
                        Image = pathBook,
                        Description = "This is a book witten by Author a couple of books like lorem At vero eos et accusamus et iusto odio " +
                        "dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias " +
                        "excepturi sint occaecati cupiditate non provident" +
                       " similique sunt in culpa qui officia deserunt mollitia animi, " +
                        "id est laborum et dolorum fuga.Et harum quidem rerum facilis est et expedita distinctio. ",
                        Title = "Book Title",
                        Price = price,
                        Discount = discount,
                        Quantity = quantity,
                        PriceAfterDiscount = (price - (price * discount) / 100)

                    };
                    context.Books.Add(book);
                }
                context.SaveChanges();
            }





        }
    }
}
