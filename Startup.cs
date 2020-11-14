using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendAssignmentPt2.Models;
using BackendAssignmentPt2.Models.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BackendAssignmentPt2
{
    public class Startup
    {
        public Startup(IConfiguration config)
        {
            Configuration = config;
        }
        private IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            // Enabling sessions to store details of a user’s cart
            services.AddMemoryCache();
            services.AddSession();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDbContext<StoreDbContext>(opts =>
            {
                opts.UseSqlServer(
                Configuration["ConnectionStrings:StoreConnection"]);
            });
            // Registering/create a service for the IStoreRepository
            // interface that uses EFStoreRepository as the implementation class. This allows classes to use interfaces 
            // without needing to know which implementation class is being used.
            services.AddScoped<IStoreRepository, StoreRepository>();
            // AddScoped method creates a service where each HTTP request gets its own repository object
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePages();

            app.UseStaticFiles();
            // UseSession method allows the session system to automatically associate
            // requests with sessions when they arrive from the client
            app.UseSession();

            app.UseRouting();
            // We create a more useful set of URLs - a scheme that follows the pattern of composable URLs
            // that makes sense to the user. It is a combination of using static 
            // (string literals - “Catalogue”, “Page) and dynamic ({category}, {productPage}) content in a segment.
            // When we map multiple routing patterns, we must code the most specific pattern first and
            // the most general pattern last - routes are applied in the order in which
            // they are defined(there is a precedence).
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("Catalogue",
                "Catalogue/{category}/Page{productPage:int}",
                new { Controller = "Home", action = "Index" });
                endpoints.MapControllerRoute("page", "Page{productPage:int}",
                new { Controller = "Home", action = "Index", productPage = 1 });
                endpoints.MapControllerRoute("category", "{category}",
                new { Controller = "Home", action = "Index", productPage = 1 });
                endpoints.MapControllerRoute("pagination",
                "Products/Page{productPage}",
                new { Controller = "Home", action = "Index", productPage = 1 });
                endpoints.MapDefaultControllerRoute();
            });
            // adding a call to the EnsurePopulated method on app startup to ensure the database is populated with data
            SeedData.EnsurePopulated(app);
        }
    }
}
