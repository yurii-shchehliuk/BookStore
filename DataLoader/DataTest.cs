using Domain;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataLoader
{
    public class DataTest
    {
        private readonly TestAppContext _testAppContext;
        public DataTest(TestAppContext testAppContext)
        {
            _testAppContext = testAppContext;
        }

        public void LoadData()
        {
            {
                Random random = new Random();
                int i = 0;
                foreach (var item in Directory.GetFiles(@"C:\Users\Jerzy\source\repos\TestApplication\BookStore.Web\wwwroot\img\Books"))
                {
                    i++;

                    string pathBook = "/img/Books/" + Path.GetFileName(item);
                    Book book = new Book
                    {
                        BookId = i,
                        Image = pathBook,
                        Description = "This is a book witten by Author a couple of books like lorem At vero eos et accusamus et iusto odio " +
                        "dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias " +
                        "excepturi sint occaecati cupiditate non provident" +
                       " similique sunt in culpa qui officia deserunt mollitia animi, " +
                        "id est laborum et dolorum fuga.Et harum quidem rerum facilis est et expedita distinctio. ",
                        Title = "Book Title",
                        Price = random.Next(10, 70),
                        Discount = random.Next(0, 15),
                        Quantity = random.Next(30, 100),


                    };
                    _testAppContext.Books.Add(book);
                }
            }
        }
    }
}
