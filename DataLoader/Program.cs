using DataLoader.Tables;
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
                AuthorLoader authorLoader = new AuthorLoader(context);
               // authorLoader.LoadMethod();

                BookLoader bookLoader = new BookLoader(context);
                bookLoader.LoadMethod(authorLoader.authorsCount);
            }
        }
    }
}
