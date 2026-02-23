using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using McvMovie.Data;
using System;
using System.Linq;

namespace McvMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new McvMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<McvMovieContext>>()))
            {
                if (context.Movie.Any())
                {
                    return; 
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Romantic Comedy",
                        Rating = "13",
                        Price = 7.99M
                    },
                    new Movie
                    {
                        Title = "Ghostbusters",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comedy",
                        Rating = "13",
                        Price = 8.99M
                    },
                    new Movie
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Comedy",
                        Rating = "13",
                        Price = 9.99M
                    },
                    new Movie
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Rating = "R",
                        Price = 3.99M
                    }
                );

                context.SaveChanges();
            }
        }
    }
}