using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using practice;
using ownpractice.Entities;

namespace ownpractice
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            Database.EnsureDeleted();
        }
        public DbSet<DbMovie> dbMovies { get; set; }
        public DbSet<UserList> userLists { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Movies;Trusted_Connection=True;");
            }
        }

    }
}