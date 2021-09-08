using EmployeeManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.API.Models
{
    interface IDepartmentRepository
    {
        public IEnumerable<Department> GetDepartments();
        Department GetDepartment(int departmentId);
    }
}
