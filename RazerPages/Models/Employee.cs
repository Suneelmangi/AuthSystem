using System.ComponentModel.DataAnnotations;

namespace RazerPages.Models
{
    public class Employee
    {
        [Key]
        public int Eid { get; set; }
        [Required]
        public string Ename { get; set; }

        public string Egender { get; set; }
        [Required]
        public string Ephone { get; set; }
        public string Eaddress { get; set; }
    }
}
