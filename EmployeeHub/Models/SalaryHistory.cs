using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeHub.Models
{
    public class SalaryHistory
    {
        // Primary Key
        [Key]
        public int SalaryID { get; set; }

        // Foreign Key to Employee
        public int EmployeeID { get; set; }

        // Navigation property to Employee
        public Employee Employee { get; set; }

        public decimal SalaryAmount { get; set; }

        public DateTime EffectiveDate { get; set; }

        // Foreign Key to Department
        public int DepartmentID { get; set; }

        // Navigation property to Department
        public Department Department { get; set; }
    }
}
