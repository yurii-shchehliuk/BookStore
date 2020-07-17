using Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Domain
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            TestAppContext context =
                applicationBuilder.ApplicationServices.GetRequiredService<TestAppContext>();


            if (!context.Books.Any())
            {
                context.AddRange
                (new Book
                {
                    Image=@"C:\Users\Jerzy\source\repos\TestApplication\BookStore.Web\wwwroot\img\Books\3OVAxVVhAeE.jpg",
                    Price=50,
                    Discount=0,
                    Quantity=14
                },new Book
                {
                    Image=@"C:\Users\Jerzy\source\repos\TestApplication\BookStore.Web\wwwroot\img\Books\f8sNEYR1GS4.jpg",
                    Price=40,
                    Discount=0,
                    Quantity=14
                },new Book
                {
                    Image=@"C:\Users\Jerzy\source\repos\TestApplication\BookStore.Web\wwwroot\img\Books\fB4Cro5nwCg.jpg",
                    Price=60,
                    Discount=0,
                    Quantity=14
                },new Book
                {
                    Image=@"C:\Users\Jerzy\source\repos\TestApplication\BookStore.Web\wwwroot\img\Books\HdbMcallbt0.jpg",
                    Price=60,
                    Discount=0,
                    Quantity=14
                },new Book
                {
                    Image=@"C:\Users\Jerzy\source\repos\TestApplication\BookStore.Web\wwwroot\img\Books\HVJ4YAWOApk.jpg",
                    Price=14,
                    Discount=0,
                    Quantity=14
                }
                
                
                );
            }

            context.SaveChanges();
        }
    }
}
