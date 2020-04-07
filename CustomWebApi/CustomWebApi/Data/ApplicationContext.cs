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
                modelBuilder.Entity<Movie>()
                    .HasData(
                        new Movie { MovieId = 1, Name = "The Departed" },
                        new Movie { MovieId = 2, Name = "Pulp Fiction" },
                        new Movie { MovieId = 3, Name = "The Shawshank Redemption" },
                        new Movie { MovieId = 4, Name = "The Lion King" },
                        new Movie { MovieId = 5, Name = "Titanic" },
                        new Movie { MovieId = 6, Name = "The Big Lebowski" },
                        new Movie { MovieId = 7, Name = "Before Sunrise" },
                        new Movie { MovieId = 8, Name = "Jurassic Park" },
                        new Movie { MovieId = 9, Name = "Toy Story 2" },
                        new Movie { MovieId = 10, Name = "Thelma and Louise" }
                    );
                modelBuilder.Entity<Music>()
                    .HasData(
                        new Music { MusicId = 1, Name = "The Beatles" },
                        new Music { MusicId = 2, Name = "Guns N' Roses" },
                        new Music { MusicId = 3, Name = "Pink Floyd" },
                        new Music { MusicId = 4, Name = "Led Zeppelin" },
                        new Music { MusicId = 5, Name = "Queen" },
                        new Music { MusicId = 6, Name = "The Rolling Stones" },
                        new Music { MusicId = 7, Name = "Elvis Presley" },
                        new Music { MusicId = 8, Name = "Michael Jackson" },
                        new Music { MusicId = 9, Name = "Elton John" },
                        new Music { MusicId = 10, Name = "Madonna" },
                        new Music { MusicId = 11, Name = "Rihanna"},
                        new Music { MusicId = 12, Name = "Eminem"},
                        new Music { MusicId = 13, Name = "Taylor Swift"},
                        new Music { MusicId = 14, Name = "Mariah Carey"},
                        new Music { MusicId = 15, Name = "Eagles"}
                        );
                modelBuilder.Entity<Sport>()
                    .HasData(
                        new Sport { SportId = 1, Name = "American Football"},
                        new Sport { SportId = 2, Name = "Baseball"},
                        new Sport { SportId = 3, Name = "Basketball"},
                        new Sport { SportId = 4, Name = "Hockey"},
                        new Sport { SportId = 5, Name = "Soccer"}
                    );
            }
        
            public DbSet<Activity> Activities { get; set; }
            public DbSet<Fandom> Fandoms { get; set; }
            public DbSet<Movie> Movies { get; set; }
            public DbSet<Music> Music { get; set; }
            public DbSet<Sport> Sports { get; set; }
        }
    }
