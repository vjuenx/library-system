using System.ComponentModel.DataAnnotations;

namespace SimpleWindowsForm.Models
{
    public class Book
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty; // Kitap Adı
        
        [Required]
        [MaxLength(100)]
        public string Author { get; set; } = string.Empty; // Yazar
        
        [Required]
        [MaxLength(20)]
        public string ISBN { get; set; } = string.Empty; // ISBN Numarası
        
        [MaxLength(100)]
        public string Publisher { get; set; } = string.Empty; // Yayınevi
        
        public int PublicationYear { get; set; } // Yayın Yılı
        
        public int? CategoryId { get; set; } // Kategori Foreign Key
        
        [Required]
        [MaxLength(20)]
        public string ShelfLocation { get; set; } = string.Empty; // Raf Konumu (A1, B2, C3, vb.)
        
        public int TotalCopies { get; set; } = 1; // Toplam Kopya Sayısı
        
        public int AvailableCopies { get; set; } = 1; // Mevcut Kopya Sayısı
        
        public bool IsActive { get; set; } = true; // Aktif mi?
        
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty; // Açıklama
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        public DateTime? UpdatedDate { get; set; }
        
        // Navigation property
        public virtual Category? Category { get; set; }
        
        // Hesaplanan özellik - Ödünç verilen kopya sayısı
        public int BorrowedCopies => TotalCopies - AvailableCopies;
        
        // Kitap mevcut mu?
        public bool IsAvailable => AvailableCopies > 0;
        
        // Görüntüleme için string
        public override string ToString()
        {
            string categoryName = Category?.Name ?? "Kategori Yok";
            return $"{Title} - {Author} ({categoryName}) - Raf: {ShelfLocation} - Mevcut: {AvailableCopies}/{TotalCopies}";
        }
    }
} 