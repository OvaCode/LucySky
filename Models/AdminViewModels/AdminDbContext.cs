using System;
using Microsoft.EntityFrameworkCore;

namespace LucySkyAdmin.Models.AdminViewModels
{
    public class AdminDbContext: DbContext
    {
        
        public AdminDbContext()
        {
        }

        public DbSet<Sentence> Sentences { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=LucySkyDb.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    public class Sentence
    {
        public string Id { get; set; }
        public string Text { get; set; }
    }
}
