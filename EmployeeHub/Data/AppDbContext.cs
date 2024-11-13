using Microsoft.EntityFrameworkCore;
using EmployeeHub.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace EmployeeHub.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<SalaryHistory> SalaryHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Employee-Department Relationship (FK)
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany()  // A department can have many employees
                .HasForeignKey(e => e.DepartmentID)
                .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete

            // SalaryHistory-Employee Relationship (FK)
            modelBuilder.Entity<SalaryHistory>()
                .HasOne(s => s.Employee)
                .WithMany()  // An employee can have many salary records
                .HasForeignKey(s => s.EmployeeID)
                .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete

            // SalaryHistory-Department Relationship (FK)
            modelBuilder.Entity<SalaryHistory>()
                .HasOne(s => s.Department)
                .WithMany()  // A department can have many salary records
                .HasForeignKey(s => s.DepartmentID)
                .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete

            base.OnModelCreating(modelBuilder);
        }
    }
}
