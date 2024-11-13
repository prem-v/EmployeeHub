using System.ComponentModel.DataAnnotations;

namespace EmployeeHub.Models
{
    public class Department
    {
        // Primary Key
        [Key]
        public int DepartmentID { get; set; }

        [Required]
        public string DepartmentName { get; set; }
    }
}
