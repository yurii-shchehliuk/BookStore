using DataLoader.Tables;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using OPT_Faktury.Core;
using OPT_Faktury.Data;
using System;
using System.Collections.Generic;
using System.IO;

namespace DataLoader
{
    class Program
    {
        static void Main(string[] args)
        {

            Configuration programConfiguration;
            programConfiguration = ConfigurationMenager.ReadConfiguration();

          
            var optionsBuilder = new DbContextOptionsBuilder<TestAppContext>();
            optionsBuilder.UseSqlServer(programConfiguration.Connection.ConnectionString);

            using (var context = new TestAppContext(optionsBuilder.Options))
            {
                AuthorLoader authorLoader = new AuthorLoader(context);
               // authorLoader.LoadMethod();

                BookLoader bookLoader = new BookLoader(context);
                bookLoader.LoadMethod(authorLoader.authorsCount, programConfiguration.BooksPath);
            }
        }
    }
}
