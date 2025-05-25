using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleWindowsForm.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        
        [Required]
        public int StudentId { get; set; }
        
        [Required]
        public int BookId { get; set; }
        
        [Required]
        public DateTime ReservationDate { get; set; } = DateTime.Now;
        
        [Required]
        public DateTime ExpiryDate { get; set; }
        
        public bool IsActive { get; set; } = true;
        
        public bool IsFulfilled { get; set; } = false;
        
        public DateTime? FulfilledDate { get; set; }
        
        [Required]
        public int CreatedBy { get; set; }
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        public string? Notes { get; set; }
        
        // Navigation properties
        public virtual Student? Student { get; set; }
        public virtual Book? Book { get; set; }
        public virtual User? CreatedByUser { get; set; }
    }
} 