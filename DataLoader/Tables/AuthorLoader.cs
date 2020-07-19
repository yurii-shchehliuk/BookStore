using Domain;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataLoader.Tables
{
    public class AuthorLoader
    {
        private readonly TestAppContext context;
        public AuthorLoader(TestAppContext _context)
        {
            context = _context;
        }
        public void LoadMethod()
        {
            Random random = new Random();
            foreach (var item in Directory.GetFiles(@"C:\Users\Jerzy\source\repos\TestApplication\BookStore.Web\wwwroot\img\authors"))
            {
                string pathBook = "/img/authors/" + Path.GetFileName(item);
              

                Author author = new Author
                {
                    Image = pathBook,
                    Bio = "This is a book witten by Author a couple of books like lorem At vero eos et accusamus et iusto odio " +
                    "dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias " +
                    "excepturi sint occaecati cupiditate non provident" +
                   " similique sunt in culpa qui officia deserunt mollitia animi, " +
                    "id est laborum et dolorum fuga.Et harum quidem rerum facilis est et expedita distinctio. ",
                   
                    
                };
                context.Authors.Add(author);
            }
            context.SaveChanges();
        }
    }
}
