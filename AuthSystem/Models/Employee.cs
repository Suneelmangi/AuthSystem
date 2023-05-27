using Microsoft.Build.Framework;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace AuthSystem.Models
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
