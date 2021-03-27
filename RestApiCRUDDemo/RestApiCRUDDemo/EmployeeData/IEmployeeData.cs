using RestApiCRUDDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiCRUDDemo.EmployeeData
{
   public interface IEmployeeData
    {
        List<Employee> GetEmployees();

        Employee FindEmployee(Guid id);
        Employee AddEmployee(Employee employee);
        Employee EditEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
    }
}
