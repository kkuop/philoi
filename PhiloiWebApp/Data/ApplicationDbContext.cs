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
                 new Categories { CategoriesId = 1, Name = "Fandoms" },
                 new Categories { CategoriesId = 2, Name = "Sports" },
                 new Categories { CategoriesId = 3, Name = "Music" },
                 new Categories { CategoriesId = 4, Name = "Activites" },
                 new Categories { CategoriesId = 5, Name = "Movies" }
              );

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole 
            { Name = "Admin", NormalizedName = "ADMIN" 
            
            },
                new IdentityRole { Name = "User", NormalizedName = "USER"}
                );
        }
      
    

    

        public DbSet<User> User { get; set; }
        public DbSet<Interests> Interests { get; set; }
        public DbSet<Categories> Categories { get; set; }
    }
}
