using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhiloiWebApp.Models;

namespace PhiloiWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Categories>()
              .HasData(
                 new Categories { CategoriesId = 1, Name = "Fandoms"},
                 new Categories { CategoriesId = 2, Name = "Sports" },
                 new Categories { CategoriesId = 3, Name = "Music" },
                 new Categories { CategoriesId = 4, Name = "Activites" },
                 new Categories { CategoriesId = 5, Name = "Movies" }
              );
            modelBuilder.Entity<IdentityRole>()
                .HasData(
                new IdentityRole { Name = "Admin", NormalizedName = "ADMIN", Id= "07e98e2e-8bbf-457d-8564-a619c36ab27f" , ConcurrencyStamp= "ca934950-ebfb-45a3-9ae5-9e483ab35528" },
                new IdentityRole { Name = "User", NormalizedName = "USER", Id= "65bddf41-6651-40b8-80be-0bcbab5d89a9", ConcurrencyStamp= "24788613-e613-4e77-9f96-948472358639" });
        }

        public DbSet<User> User { get; set; }
        public DbSet<UserInterest> UserInterests { get; set; }
        public DbSet<Interests> Interests { get; set; }
        public DbSet<Categories> Categories { get; set; }
    }
}
