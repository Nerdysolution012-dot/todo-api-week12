using System.ComponentModel.DataAnnotations;

namespace TodoAPI.Models
{
    public class TodoItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public bool IsCompleted { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? DueDate { get; set; }

        [Required]
        [MaxLength(10)]
        public string Priority { get; set; } // Low, Medium, Hig
    }
}
