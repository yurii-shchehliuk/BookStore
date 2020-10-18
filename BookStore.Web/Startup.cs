using Application.ApplicationServices;
using Application.CommandHandler.GenreCommand;
using Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace BookStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        //private IConfigurationRoot _configurationRoot;
        /// This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<Domain.AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                x => x.MigrationsAssembly("Domain")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<Domain.AppDbContext>()
                    .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options => options.LoginPath = "/Account/LogIn");


            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddHttpContextAccessor();

            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IGenre, GenreRepository>();
            services.AddScoped<IBook, Application.CommandHandler.BookCommand.BookRepository>();
            services.AddScoped<IOrder, Application.CommandHandler.OrderCommand.OrderRepository>();
            services.AddScoped(sp => ShoppingCart.GetCart(sp));


            services.AddMvc();
            services.AddMemoryCache();

            services.AddDistributedMemoryCache(); /// Adds a default in-memory implementation of IDistributedCache
            services.Configure<CookiePolicyOptions>(options =>
            {
                /// This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            //-------
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);

            });
        }

        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                /// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            /// IMPORTANT: This session call MUST go before UseMvc()
            app.UseSession();
            /// Add MVC to the request pipeline.

            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});
            //DbInitializer.Seed(app);
        }
    }
}
