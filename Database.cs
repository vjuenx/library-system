using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using SimpleWindowsForm.Data;
using SimpleWindowsForm.Models;
using System;
using System.IO;

namespace SimpleWindowsForm
{
    public class Database
    {
        private string connectionString;
        private string dbPath;
        private AppDbContext? dbContext;

        public Database()
        {
            // Veritabanı dosyasını proje klasöründe oluştur
            dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "simple_ef_database.db");
            connectionString = $"Data Source={dbPath}";
            
            // Entity Framework ile veritabanını başlat
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            try
            {
                dbContext = new AppDbContext();
                
                // Veritabanını oluştur (migration olmadan)
                dbContext.Database.EnsureCreated();
                
                // Test verisi ekle (eğer tablo boşsa)
                if (!dbContext.Students.Any())
                {
                    var testStudent = new Student
                    {
                        Name = "Test Öğrenci",
                        StudentNumber = "2024001",
                        Email = "test@example.com",
                        CreatedDate = DateTime.Now
                    };
                    
                    dbContext.Students.Add(testStudent);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Entity Framework veritabanı başlatılamadı: {ex.Message}");
            }
        }

        public bool TestConnection()
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    return context.Database.CanConnect();
                }
            }
            catch
            {
                return false;
            }
        }

        public string GetDatabasePath()
        {
            return dbPath;
        }

        public AppDbContext GetDbContext()
        {
            return new AppDbContext();
        }

        // Entity Framework ile öğrenci sayısını al
        public int GetStudentCount()
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    return context.Students.Count();
                }
            }
            catch
            {
                return 0;
            }
        }

        // Eski SQLite bağlantısı (geriye uyumluluk için)
        public SqliteConnection GetConnection()
        {
            return new SqliteConnection(connectionString);
        }

        public void Dispose()
        {
            dbContext?.Dispose();
        }
    }
} 