using Domain;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DataLoader.Tables
{
    public class BookLoader
    {
        private readonly TestAppContext context;
        public int bookCount = 0;

        public BookLoader(TestAppContext _context)
        {
            context = _context;
            bookCount=_context.Books.Count();
        }
        public void LoadMethod()
        {
            Random random = new Random();
            foreach (var item in Directory.GetFiles(@"C:\Users\Jerzy\source\repos\TestApplication\BookStore.Web\wwwroot\img\Books"))
            {
                bookCount++;
                string pathBook = "/img/Books/" + Path.GetFileName(item);
                float price = random.Next(10, 70);
                int discount = random.Next(10, 50);
                int quantity = random.Next(30, 100);
                int isNew = random.Next(0, 2);
                bool isnew = Convert.ToBoolean(isNew);
                Book book = new Book
                {
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
                    PriceAfterDiscount = (price - (price * discount) / 100),
                    IsThisNew = isnew,
                    InStock=70
                    

                };
                context.Books.Add(book);
            }
            context.SaveChanges();
        }
    }
}
