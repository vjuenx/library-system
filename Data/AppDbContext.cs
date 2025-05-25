using Microsoft.EntityFrameworkCore;
using SimpleWindowsForm.Models;

namespace SimpleWindowsForm.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Veritabanı dosyasını proje klasöründe oluştur
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "simple_ef_database.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Student tablosu için konfigürasyon
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.StudentNumber).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Email).HasMaxLength(200);
                entity.Property(e => e.CreatedDate).IsRequired();
                
                // Unique constraint for student number
                entity.HasIndex(e => e.StudentNumber).IsUnique();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
} 