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

                // Test görevli verisi ekle (eğer tablo boşsa)
                if (!dbContext.Employees.Any())
                {
                    var testEmployees = new List<Employee>
                    {
                        new Employee
                        {
                            FullName = "Ahmet Yılmaz",
                            EmployeeNumber = "EMP001",
                            Email = "ahmet.yilmaz@kutuphane.com",
                            Phone = "0532 123 4567",
                            Department = "Kütüphane",
                            Position = "Kütüphaneci",
                            Salary = 15000,
                            HireDate = DateTime.Now.AddYears(-2),
                            IsActive = true,
                            CreatedDate = DateTime.Now
                        },
                        new Employee
                        {
                            FullName = "Fatma Demir",
                            EmployeeNumber = "EMP002",
                            Email = "fatma.demir@kutuphane.com",
                            Phone = "0533 987 6543",
                            Department = "Kütüphane",
                            Position = "Kıdemli Kütüphaneci",
                            Salary = 18000,
                            HireDate = DateTime.Now.AddYears(-5),
                            IsActive = true,
                            CreatedDate = DateTime.Now
                        }
                    };
                    
                    dbContext.Employees.AddRange(testEmployees);
                    dbContext.SaveChanges();
                }

                // Test kitap verisi ekle (eğer tablo boşsa)
                if (!dbContext.Books.Any())
                {
                    var testBooks = new List<Book>
                    {
                        new Book
                        {
                            Title = "Suç ve Ceza",
                            Author = "Fyodor Dostoyevski",
                            ISBN = "9789750719387",
                            Publisher = "İş Bankası Kültür Yayınları",
                            PublicationYear = 2019,
                            Category = "Klasik Edebiyat",
                            ShelfLocation = "A1",
                            TotalCopies = 3,
                            AvailableCopies = 3,
                            IsActive = true,
                            Description = "Rus edebiyatının başyapıtlarından biri",
                            CreatedDate = DateTime.Now
                        },
                        new Book
                        {
                            Title = "1984",
                            Author = "George Orwell",
                            ISBN = "9789750738265",
                            Publisher = "Can Yayınları",
                            PublicationYear = 2020,
                            Category = "Distopya",
                            ShelfLocation = "B2",
                            TotalCopies = 2,
                            AvailableCopies = 1,
                            IsActive = true,
                            Description = "Totaliter rejimler hakkında ünlü distopik roman",
                            CreatedDate = DateTime.Now
                        },
                        new Book
                        {
                            Title = "Algoritma ve Programlama",
                            Author = "Mehmet Özkan",
                            ISBN = "9786052112458",
                            Publisher = "Seçkin Yayıncılık",
                            PublicationYear = 2021,
                            Category = "Bilgisayar Bilimleri",
                            ShelfLocation = "C3",
                            TotalCopies = 5,
                            AvailableCopies = 4,
                            IsActive = true,
                            Description = "Programlama temelleri ve algoritma tasarımı",
                            CreatedDate = DateTime.Now
                        }
                    };
                    
                    dbContext.Books.AddRange(testBooks);
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

        // Entity Framework ile görevli sayısını al
        public int GetEmployeeCount()
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    return context.Employees.Count(e => e.IsActive);
                }
            }
            catch
            {
                return 0;
            }
        }

        // Entity Framework ile kitap sayısını al
        public int GetBookCount()
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    return context.Books.Count();
                }
            }
            catch
            {
                return 0;
            }
        }

        // Mevcut kitap sayısını al
        public int GetAvailableBookCount()
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    return context.Books.Where(b => b.AvailableCopies > 0).Count();
                }
            }
            catch
            {
                return 0;
            }
        }

        // BorrowRecord metodları
        public int GetBorrowRecordCount()
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    return context.BorrowRecords.Count();
                }
            }
            catch
            {
                return 0;
            }
        }

        public int GetActiveBorrowCount()
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    return context.BorrowRecords.Where(br => !br.IsReturned).Count();
                }
            }
            catch
            {
                return 0;
            }
        }

        public int GetOverdueBorrowCount()
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    return context.BorrowRecords
                        .Where(br => !br.IsReturned && br.DueDate < DateTime.Now)
                        .Count();
                }
            }
            catch
            {
                return 0;
            }
        }

        // Reservation metodları
        public int GetReservationCount()
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    return context.Reservations.Count();
                }
            }
            catch
            {
                return 0;
            }
        }

        public int GetActiveReservationCount()
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    return context.Reservations.Where(r => r.IsActive && !r.IsFulfilled).Count();
                }
            }
            catch
            {
                return 0;
            }
        }

        public int GetExpiredReservationCount()
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    return context.Reservations
                        .Where(r => r.IsActive && !r.IsFulfilled && r.ExpiryDate < DateTime.Now)
                        .Count();
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