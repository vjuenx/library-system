using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleWindowsForm.Models
{
    public class BorrowRecord
    {
        public int Id { get; set; }
        
        [Required]
        public int StudentId { get; set; }
        
        [Required]
        public int BookId { get; set; }
        
        [Required]
        public DateTime BorrowDate { get; set; }
        
        [Required]
        public DateTime DueDate { get; set; }
        
        public DateTime? ReturnDate { get; set; }
        
        public bool IsReturned { get; set; } = false;
        
        public decimal LateFee { get; set; } = 0;
        
        [Required]
        public int CreatedBy { get; set; }
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        // Navigation properties
        public virtual Student? Student { get; set; }
        public virtual Book? Book { get; set; }
        public virtual User? CreatedByUser { get; set; }
    }
} 