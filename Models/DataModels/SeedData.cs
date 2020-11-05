using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAssignmentPt2.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            StoreDbContext context = app.ApplicationServices
            .CreateScope().ServiceProvider.GetRequiredService<StoreDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                new Category
                {
                    CategoryName = "Book"
                },
                new Category
                {
                    CategoryName = "Movie"
                },
                new Category
                {
                    CategoryName = "MusicCD"
                }
                );
                context.SaveChanges();
            }
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                new Movie
                {
                    Title = "Jungle Book",
                    Price = 175,
                    ImageFileName = "junglebook.jpg",
                    Director = "Jon Favreau",
                    CategoryId = 2,
                },
                new Movie
                {
                    Title = "Gladiator",
                    Price = 150.20m,
                    ImageFileName = "gladiator.jpg",
                    Director = "Ridley Scott",
                    CategoryId = 2,
                },
                new Movie
                {
                    Title = "Forest Gump",
                    Price = 154.50m,
                    ImageFileName = "forrest-gump.jpg",
                    Director = "Robert Zemeckis",
                    CategoryId = 2,
                },
                new Book
                {
                    Author = "Steve Turner",
                    Title = "A Hard Day's Write: The Stories Behind Every Beatles Song",
                    Price = 190.75m,
                    Published = 2005,
                    ImageFileName = "hard_day.jpg",
                    ISBN = "978-0316547833",
                    Publisher = "Little Brown & Co",
                    CategoryId = 1
                },
                new Book
                {
                    Author = "George Martin",
                    Title = "With a Little Help from My Friends: The Making of Sgt. Pepper",
                    Price = 120.60m,
                    Published = 1995,
                    ImageFileName = "pepper.jpg",
                    ISBN = "978-0316547833",
                    Publisher = "Little Brown & Co",
                    CategoryId = 1
                },
                new MusicCD
                {
                    Artist = "Beatles",
                    Title = "Abbey Road (Remastered)",
                    Price = 128m,
                    CDReleased = 2009,
                    ImageFileName = "abbey_road.jpg",
                    Label = "Capitol",
                    CategoryId = 3
                }
                );
                context.SaveChanges();
                if (!context.Tracks.Any())
                {
                    context.Tracks.AddRange(
                    new Track
                    {
                        Title = "Oh! Darling",
                        Length = new TimeSpan(0, 3, 26),
                        Composer = "Lenon, McCartney",
                        ProductId = 6
                    }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
