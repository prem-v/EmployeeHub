using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeHub.Models
{
    public class Employee
    {
        // Primary Key
        [Key]
        public int EmployeeID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        // Foreign Key to Department
        [ForeignKey("Department")]
        [Required]  // Ensure this is required if each Employee must belong to a Department
        public int DepartmentID { get; set; }

        public DateTime HireDate { get; set; }

         // Navigation property to Department
        public Department Department { get; set; }
    }
}
