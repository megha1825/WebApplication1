using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Database.Entity
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required,MaxLength(100)]
        public string EmployeeName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
