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
                
                // Test öğrenci verisi ekle (eğer tablo boşsa)
                if (!dbContext.Students.Any())
                {
                    var testStudents = new List<Student>
                    {
                        new Student
                        {
                            Name = "Ali Veli",
                            StudentNumber = "2024001",
                            Email = "ali.veli@ogrenci.edu.tr",
                            CreatedDate = DateTime.Now
                        },
                        new Student
                        {
                            Name = "Ayşe Yılmaz",
                            StudentNumber = "2024002",
                            Email = "ayse.yilmaz@ogrenci.edu.tr",
                            CreatedDate = DateTime.Now
                        },
                        new Student
                        {
                            Name = "Mehmet Demir",
                            StudentNumber = "2024003",
                            Email = "mehmet.demir@ogrenci.edu.tr",
                            CreatedDate = DateTime.Now
                        },
                        new Student
                        {
                            Name = "Fatma Kaya",
                            StudentNumber = "2024004",
                            Email = "fatma.kaya@ogrenci.edu.tr",
                            CreatedDate = DateTime.Now
                        },
                        new Student
                        {
                            Name = "Ahmet Özkan",
                            StudentNumber = "2024005",
                            Email = "ahmet.ozkan@ogrenci.edu.tr",
                            CreatedDate = DateTime.Now
                        },
                        new Student
                        {
                            Name = "Zeynep Çelik",
                            StudentNumber = "2024006",
                            Email = "zeynep.celik@ogrenci.edu.tr",
                            CreatedDate = DateTime.Now
                        },
                        new Student
                        {
                            Name = "Mustafa Arslan",
                            StudentNumber = "2024007",
                            Email = "mustafa.arslan@ogrenci.edu.tr",
                            CreatedDate = DateTime.Now
                        },
                        new Student
                        {
                            Name = "Elif Şahin",
                            StudentNumber = "2024008",
                            Email = "elif.sahin@ogrenci.edu.tr",
                            CreatedDate = DateTime.Now
                        }
                    };
                    
                    dbContext.Students.AddRange(testStudents);
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
                    // Önce kategorileri oluştur
                    CreateDefaultCategories();
                    
                    var testBooks = new List<Book>
                    {
                        new Book
                        {
                            Title = "Suç ve Ceza",
                            Author = "Fyodor Dostoyevski",
                            ISBN = "9789750719387",
                            Publisher = "İş Bankası Kültür Yayınları",
                            PublicationYear = 2019,
                            CategoryId = 1, // Klasik Edebiyat
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
                            CategoryId = 2, // Bilim Kurgu
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
                            CategoryId = 3, // Bilgisayar Bilimleri
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

        private void CreateDefaultCategories()
        {
            using (var context = new AppDbContext())
            {
                // Eğer hiç kategori yoksa varsayılan kategorileri oluştur
                if (!context.Categories.Any())
                {
                    var defaultCategories = new List<Category>
                    {
                        new Category
                        {
                            Name = "Klasik Edebiyat",
                            Description = "Dünya edebiyatının klasik eserleri",
                            IsActive = true,
                            CreatedDate = DateTime.Now
                        },
                        new Category
                        {
                            Name = "Bilim Kurgu",
                            Description = "Bilim kurgu ve fantastik romanlar",
                            IsActive = true,
                            CreatedDate = DateTime.Now
                        },
                        new Category
                        {
                            Name = "Bilgisayar Bilimleri",
                            Description = "Programlama, algoritma ve teknoloji kitapları",
                            IsActive = true,
                            CreatedDate = DateTime.Now
                        },
                        new Category
                        {
                            Name = "Tarih",
                            Description = "Tarih ve biyografi kitapları",
                            IsActive = true,
                            CreatedDate = DateTime.Now
                        },
                        new Category
                        {
                            Name = "Felsefe",
                            Description = "Felsefe ve düşünce kitapları",
                            IsActive = true,
                            CreatedDate = DateTime.Now
                        },
                        new Category
                        {
                            Name = "Çocuk Kitapları",
                            Description = "Çocuklar için hikaye ve eğitici kitaplar",
                            IsActive = true,
                            CreatedDate = DateTime.Now
                        },
                        new Category
                        {
                            Name = "Akademik",
                            Description = "Üniversite ve akademik çalışma kitapları",
                            IsActive = true,
                            CreatedDate = DateTime.Now
                        }
                    };

                    context.Categories.AddRange(defaultCategories);
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

        // Category metodları
        public int GetCategoryCount()
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    return context.Categories.Count(c => c.IsActive);
                }
            }
            catch
            {
                return 0;
            }
        }

        public int GetBookCountByCategory(int categoryId)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    return context.Books.Count(b => b.CategoryId == categoryId && b.IsActive);
                }
            }
            catch
            {
                return 0;
            }
        }

        public List<Category> GetActiveCategories()
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    return context.Categories
                        .Where(c => c.IsActive)
                        .OrderBy(c => c.Name)
                        .ToList();
                }
            }
            catch
            {
                return new List<Category>();
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