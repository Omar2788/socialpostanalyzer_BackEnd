using socialpostanalyzer.Models;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace socialpostanalyzer.DBContext
{
    public class SocialDbContext : DbContext
    {
        public SocialDbContext(DbContextOptions<SocialDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserPages>()
               .HasKey(bc => new { bc.id, bc.UserId });
            modelBuilder.Entity<UserPages>()
               .HasOne(bc => bc.Pages)
               .WithMany(b => b.UserPages)
               .HasForeignKey(bc => bc.id);
            modelBuilder.Entity<UserPages>()
               .HasOne(bc => bc.Users)
               .WithMany(c => c.UserPages)
               .HasForeignKey(bc => bc.UserId);

            

        }
        public DbSet<Page> Pages { get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<Post> Post { get; set; }

        public DbSet<Reaction> Reaction { get; set; }
        public DbSet<Shares> Shares{ get; set; }
        public DbSet<Comment> Comment { get; set; }



        public DbSet<UserPages> UserPages { get; set; }


    }
}
