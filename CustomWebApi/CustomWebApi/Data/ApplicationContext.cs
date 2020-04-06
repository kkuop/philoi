using CustomWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomWebApi.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options)
             : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Seed data - needs migration
            modelBuilder.Entity<Activity>()
              .HasData(
                 new Activity { ActivityId = 1, Name = "Hiking" },
                 new Activity { ActivityId = 2, Name = "Running" },
                 new Activity { ActivityId = 3, Name = "Camping" },
                 new Activity { ActivityId = 4, Name = "Traveling" },
                 new Activity { ActivityId = 5, Name = "Gardening" },
                 new Activity { ActivityId = 6, Name = "Fishing" },
                 new Activity { ActivityId = 7, Name = "Hunting" },
                 new Activity { ActivityId = 8, Name = "Exercising" },
                 new Activity { ActivityId = 9, Name = "Bicycling" },
                 new Activity { ActivityId = 10, Name = "Swimming" },
                 new Activity { ActivityId = 11, Name = "Boating" },
                 new Activity { ActivityId = 12, Name = "Skiing" },
                 new Activity { ActivityId = 13, Name = "Bowling" },
                 new Activity { ActivityId = 14, Name = "Reading" },
                 new Activity { ActivityId = 15, Name = "Kayaking" },
                 new Activity { ActivityId = 16, Name = "Cooking" },
                 new Activity { ActivityId = 17, Name = "Painting" },
                 new Activity { ActivityId = 18, Name = "Gaming" },
                 new Activity { ActivityId = 19, Name = "Crafting" },
                 new Activity { ActivityId = 20, Name = "Collecting" }
              );
            modelBuilder.Entity<Fandom>()
             .HasData(
                new Fandom { FandomId = 1, Name = "The Lord of the Rings" },
                new Fandom { FandomId = 2, Name = "Harry Potter" },
                new Fandom { FandomId = 3, Name = "Star Wars" },
                new Fandom { FandomId = 4, Name = "Game of Thrones" },
                new Fandom { FandomId = 5, Name = "Marvel" },
                new Fandom { FandomId = 6, Name = "Stranger Things" },
                new Fandom { FandomId = 7, Name = "The DC Universe" },
                new Fandom { FandomId = 8, Name = "Pokemon" },
                new Fandom { FandomId = 9, Name = "Star Trek" },
                new Fandom { FandomId = 10, Name = "The Walking Dead" },
                new Fandom { FandomId = 11, Name = "Fortnite" },
                new Fandom { FandomId = 12, Name = "Minecraft" }

             );
        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Fandom> Fandoms { get; set; }
    }
}
