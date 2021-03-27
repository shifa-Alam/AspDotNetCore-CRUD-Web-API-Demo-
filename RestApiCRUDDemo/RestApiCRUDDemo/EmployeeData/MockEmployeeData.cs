using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestApiCRUDDemo.Models;

namespace RestApiCRUDDemo.EmployeeData
{
    public class MockEmployeeData : IEmployeeData
    {
       private List<Employee> employees = new List<Employee>
        {
           new Employee
            {
               Id=Guid.NewGuid(),
               Name="Amol"
            },
           new Employee
            {
               Id=Guid.NewGuid(),
               Name="Nazrul"
            },
             new Employee
            {
               Id=Guid.NewGuid(),
               Name="Raju"
            },
               new Employee
            {
                Id=Guid.NewGuid(),
               Name="Jayanto"
            }
        };
        
        public void DeleteEmployee(Employee employee)
        {
            employees.Remove(employee);
        }

        public Employee FindEmployee(Guid id)
        {
            return employees.FirstOrDefault(e => e.Id == id);
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }

        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            employees.Add(employee);
            return employee;
        }

        public Employee EditEmployee(Employee employee)
        {

            var existingEmployee = FindEmployee(employee.Id);
            existingEmployee.Name = employee.Name;
            return existingEmployee;
        }
    }
}
