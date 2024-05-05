using LanguageLearningAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LanguageLearningAPI.Persistence.Contexts
{
    public class LanguageLearningDbContext : DbContext
    {
        public LanguageLearningDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Lesson> Lessons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Language>()
               .HasMany(l => l.Lessons)
               .WithOne(l => l.Language)
                .HasForeignKey(l => l.LanguageId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

