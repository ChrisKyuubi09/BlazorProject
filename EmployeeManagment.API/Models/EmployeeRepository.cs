using EmployeeManagment.API.Context;
using EmployeeManagment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.API.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _appDbContext;
        public EmployeeRepository(AppDbContext appDbContext)
        {
            appDbContext = _appDbContext;
        }
        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result = await  _appDbContext.EmployeesTable.AddAsync(employee);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async void DeleteEmployee(int employeeId)
        {
            var result = await _appDbContext.EmployeesTable.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
            if (result != null)
            {
                _appDbContext.EmployeesTable.Remove(result);
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task<Employee> GetEmployee(int EmployeeId)
        {
            return await _appDbContext.EmployeesTable.FirstOrDefaultAsync(e => e.EmployeeId == EmployeeId);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return _appDbContext.EmployeesTable.ToList();
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var currentEmployee = await _appDbContext.EmployeesTable.FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);

            if (currentEmployee != null)
            {
                currentEmployee.FirstName = employee.FirstName;
                currentEmployee.LastName = employee.LastName;
                currentEmployee.Email = employee.Email;
                currentEmployee.DateOfBirth = employee.DateOfBirth;
                currentEmployee.Gender = employee.Gender;
                currentEmployee.DepartmentId = employee.DepartmentId;
                currentEmployee.PhotoPath = employee.PhotoPath;

                await _appDbContext.SaveChangesAsync();

                return currentEmployee;
            }

            return null;

        }
    }
}
