using System.ComponentModel.DataAnnotations;

namespace SimpleWindowsForm.Models
{
    public class Employee
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(50)]
        public string EmployeeNumber { get; set; } = string.Empty;
        
        [MaxLength(200)]
        public string Email { get; set; } = string.Empty;
        
        [MaxLength(20)]
        public string Phone { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(50)]
        public string Department { get; set; } = string.Empty; // Kütüphane, IT, Temizlik, vb.
        
        [Required]
        [MaxLength(50)]
        public string Position { get; set; } = string.Empty; // Kütüphaneci, Müdür, Temizlik Görevlisi, vb.
        
        public decimal Salary { get; set; } = 0;
        
        public DateTime HireDate { get; set; } = DateTime.Now;
        
        public bool IsActive { get; set; } = true;
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
} 