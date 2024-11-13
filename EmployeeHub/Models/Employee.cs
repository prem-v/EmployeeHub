using System;
using System.ComponentModel.DataAnnotations;

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
        public int DepartmentID { get; set; }

        // Navigation property to Department
        public Department Department { get; set; }

        public DateTime HireDate { get; set; }
    }
}
