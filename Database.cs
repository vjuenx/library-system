using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using SimpleWindowsForm.Data;
using SimpleWindowsForm.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

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
                
                // Veritabanını sil ve yeniden oluştur (geliştirme aşamasında)
                dbContext.Database.EnsureDeleted();
                dbContext.Database.EnsureCreated();
                
                // Varsayılan admin kullanıcısı oluştur
                CreateDefaultUsers();
                
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

        private void CreateDefaultUsers()
        {
            using (var context = new AppDbContext())
            {
                // Eğer hiç kullanıcı yoksa varsayılan kullanıcıları oluştur
                if (!context.Users.Any())
                {
                    var defaultUsers = new List<User>
                    {
                        new User
                        {
                            Username = "admin",
                            Password = "123456", // Gerçek projede hash'lenmiş olmalı
                            Role = "Admin",
                            FullName = "Sistem Yöneticisi",
                            IsActive = true,
                            CreatedDate = DateTime.Now
                        },
                        new User
                        {
                            Username = "librarian",
                            Password = "123456",
                            Role = "Librarian",
                            FullName = "Kütüphaneci",
                            IsActive = true,
                            CreatedDate = DateTime.Now
                        },
                        new User
                        {
                            Username = "user",
                            Password = "123456",
                            Role = "User",
                            FullName = "Normal Kullanıcı",
                            IsActive = true,
                            CreatedDate = DateTime.Now
                        }
                    };

                    context.Users.AddRange(defaultUsers);
                    context.SaveChanges();
                }
            }
        }

        // Kullanıcı doğrulama
        public User? AuthenticateUser(string username, string password)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    return context.Users.FirstOrDefault(u => 
                        u.Username == username && 
                        u.Password == password && 
                        u.IsActive);
                }
            }
            catch
            {
                return null;
            }
        }

        // Kullanıcı sayısını al
        public int GetUserCount()
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    return context.Users.Count(u => u.IsActive);
                }
            }
            catch
            {
                return 0;
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