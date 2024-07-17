using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SolomonsAdviceWebApp.Models.Entities;

namespace SolomonsAdviceWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Advice> Advices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Advice>().HasData(
                new Advice
                {
                    Id = 1,
                    Content = "O temor do Senhor é o princípio do conhecimento; os loucos desprezam a sabedoria e a instrução.",
                    Verse = 19,
                    Chapter = 1,
                    Book = ""
                });
        }
    }
}
