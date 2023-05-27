using System.ComponentModel.DataAnnotations;

namespace AuthSystem.Models
{
    public class Students
    {
        [Key]
        public int studentID { get; set; }
        [Required]
        public string studentName { get; set; }
        [Required]
        public string studentAddress { get; set; }
    }
}
