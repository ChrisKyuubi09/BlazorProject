using EmployeeManagment.API.Context;
using EmployeeManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.API.Models
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _appDbContext;

        public DepartmentRepository(AppDbContext appDbContext)
        {
            appDbContext = _appDbContext;
        }

        public Department GetDepartment(int departmentId)
        {
            return _appDbContext.DepartmentsTable.FirstOrDefault(d => d.DepartmentId == departmentId);
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _appDbContext.DepartmentsTable.ToList();
        }
    }
}
