using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SolomonsAdviceWebApp.Models;
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
        public DbSet<FavoriteAdvice> FavoriteAdvices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Advice>().HasData(
                new Advice
                {
                    Id = 1,
                    Content = "O temor do Senhor é o princípio do conhecimento; os loucos desprezam a sabedoria e a instrução.",
                    Chapter = 1,
                    Verses = "7",
                    Book = "Provérbios"
                });
            modelBuilder.Entity<FavoriteAdvice>().HasData(
                new FavoriteAdvice
                {
                    AdviceId = 1011,
                    UserId = "11189b29-5a80-4e45-b735-c8a05da230f7"
                });
        }
    }
}
