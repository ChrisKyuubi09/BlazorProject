using EmployeeManagment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.API.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
        : base(options) 
        {
        }

        public DbSet<Employee> EmployeesTable { get; set; }
        public DbSet<Department> DepartmentsTable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 1,
                FirstName = "Chris",
                LastName = "Tatata",
                Email = "oops@gmail.com",
                DateOfBirth = new DateTime(1999, 12, 31),
                Gender = Gender.Male,
                DepartmentId = 1,
                PhotoPath = "images/chris.webp"
            });
        }
    }
}
