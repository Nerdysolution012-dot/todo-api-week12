using System.ComponentModel.DataAnnotations;

namespace TodoAPI.DTOs
{
    public class CreateTodoDto
    {


        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        [Required]
        [MaxLength(10)]
        public string Priority { get; set; } // Low, Medium, Hig
    }
}
