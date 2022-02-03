using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Models
{
    public class MovieApplicationContext: DbContext
    {
        //constructor
        public MovieApplicationContext (DbContextOptions<MovieApplicationContext> options) : base(options)
        {

        }

        public DbSet<ApplicationResponse> responses { get; set; }
        public DbSet<Category> categories { get; set; }

        //Seed 3 movies in the database
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName="Drama" },
                new Category { CategoryId = 2, CategoryName= "Action/Adventure" },
                new Category { CategoryId = 3, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 4, CategoryName = "Comedy" },
                new Category { CategoryId = 5, CategoryName = "Family" },
                new Category { CategoryId = 6, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 7, CategoryName = "Television" },
                new Category { CategoryId = 8, CategoryName = "VHS" }
                ) ;
            mb.Entity<ApplicationResponse>().HasData(

                new ApplicationResponse
                {
                    ApplicationId = 1,
                    CategoryId = 1,
                    Title = "Green Book",
                    Year = 2018,
                    Director = "Peter Farrelly",
                    Rating = "PG-13",
                    Notes = "won three awards at the 91st Academy Awards"
                },

                new ApplicationResponse
                {
                    ApplicationId = 2,
                    CategoryId = 2,
                    Title = "Interstellar",
                    Year = 2014,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false
                },

                new ApplicationResponse
                {
                    ApplicationId = 3,
                    CategoryId = 3,
                    Title = "Dead Silence",
                    Year = 2007,
                    Director = "James Wan",
                    Rating = "R",
                    Edited = true
                }
            );
        }
    }
}
