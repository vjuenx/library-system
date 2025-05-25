using System.ComponentModel.DataAnnotations;

namespace SimpleWindowsForm.Models
{
    public class Student
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(50)]
        public string StudentNumber { get; set; } = string.Empty;
        
        [MaxLength(200)]
        public string Email { get; set; } = string.Empty;
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
} 