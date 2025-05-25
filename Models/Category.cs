using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SimpleWindowsForm.Models
{
    public class Category
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        
        [MaxLength(200)]
        public string? Description { get; set; }
        
        public bool IsActive { get; set; } = true;
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        // Navigation property
        public virtual ICollection<Book>? Books { get; set; }

        // Görüntüleme için string
        public override string ToString()
        {
            int bookCount = Books?.Count(b => b.IsActive) ?? 0;
            return $"{Name} ({bookCount} kitap) - {(IsActive ? "Aktif" : "Pasif")}";
        }
    }
} 