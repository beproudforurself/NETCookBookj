using System.ComponentModel.DataAnnotations;

namespace StudentsTestAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string StudentNumber { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;
    }
}
