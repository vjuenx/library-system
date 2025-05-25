using Microsoft.EntityFrameworkCore;
using SimpleWindowsForm.Models;

namespace SimpleWindowsForm.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BorrowRecord> BorrowRecords { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Category> Categories { get; set; }

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

            // User tablosu için konfigürasyon
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Username).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Password).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Role).IsRequired().HasMaxLength(20);
                entity.Property(e => e.FullName).HasMaxLength(100);
                entity.Property(e => e.IsActive).IsRequired();
                entity.Property(e => e.CreatedDate).IsRequired();
                
                // Unique constraint for username
                entity.HasIndex(e => e.Username).IsUnique();
            });

            // Employee tablosu için konfigürasyon
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FullName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.EmployeeNumber).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Email).HasMaxLength(200);
                entity.Property(e => e.Phone).HasMaxLength(20);
                entity.Property(e => e.Department).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Position).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Salary).HasColumnType("decimal(18,2)");
                entity.Property(e => e.HireDate).IsRequired();
                entity.Property(e => e.IsActive).IsRequired();
                entity.Property(e => e.CreatedDate).IsRequired();
                
                // Unique constraint for employee number
                entity.HasIndex(e => e.EmployeeNumber).IsUnique();
            });

            // Book tablosu için konfigürasyon
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Author).IsRequired().HasMaxLength(100);
                entity.Property(e => e.ISBN).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Publisher).HasMaxLength(100);
                entity.Property(e => e.PublicationYear).IsRequired();
                entity.Property(e => e.CategoryId);
                entity.Property(e => e.ShelfLocation).IsRequired().HasMaxLength(20);
                entity.Property(e => e.TotalCopies).IsRequired();
                entity.Property(e => e.AvailableCopies).IsRequired();
                entity.Property(e => e.IsActive).IsRequired();
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.CreatedDate).IsRequired();
                
                // Unique constraint for ISBN
                entity.HasIndex(e => e.ISBN).IsUnique();
                
                // Foreign key relationship with Category
                entity.HasOne(e => e.Category)
                    .WithMany(c => c.Books)
                    .HasForeignKey(e => e.CategoryId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // Category tablosu için konfigürasyon
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Description).HasMaxLength(200);
                entity.Property(e => e.IsActive).IsRequired();
                entity.Property(e => e.CreatedDate).IsRequired();
                
                // Unique constraint for category name
                entity.HasIndex(e => e.Name).IsUnique();
            });

            // BorrowRecord tablosu için konfigürasyon
            modelBuilder.Entity<BorrowRecord>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.StudentId).IsRequired();
                entity.Property(e => e.BookId).IsRequired();
                entity.Property(e => e.BorrowDate).IsRequired();
                entity.Property(e => e.DueDate).IsRequired();
                entity.Property(e => e.ReturnDate);
                entity.Property(e => e.IsReturned).IsRequired();
                entity.Property(e => e.LateFee).HasColumnType("decimal(18,2)");
                entity.Property(e => e.CreatedBy).IsRequired();
                entity.Property(e => e.CreatedDate).IsRequired();

                // Foreign key relationships
                entity.HasOne(e => e.Student)
                    .WithMany()
                    .HasForeignKey(e => e.StudentId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Book)
                    .WithMany()
                    .HasForeignKey(e => e.BookId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.CreatedByUser)
                    .WithMany()
                    .HasForeignKey(e => e.CreatedBy)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Reservation tablosu için konfigürasyon
            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.StudentId).IsRequired();
                entity.Property(e => e.BookId).IsRequired();
                entity.Property(e => e.ReservationDate).IsRequired();
                entity.Property(e => e.ExpiryDate).IsRequired();
                entity.Property(e => e.IsActive).IsRequired();
                entity.Property(e => e.IsFulfilled).IsRequired();
                entity.Property(e => e.FulfilledDate);
                entity.Property(e => e.CreatedBy).IsRequired();
                entity.Property(e => e.CreatedDate).IsRequired();
                entity.Property(e => e.Notes).HasMaxLength(500);

                // Foreign key relationships
                entity.HasOne(e => e.Student)
                    .WithMany()
                    .HasForeignKey(e => e.StudentId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Book)
                    .WithMany()
                    .HasForeignKey(e => e.BookId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.CreatedByUser)
                    .WithMany()
                    .HasForeignKey(e => e.CreatedBy)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
} 