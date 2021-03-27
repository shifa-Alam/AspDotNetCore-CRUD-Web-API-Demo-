using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiCRUDDemo.EmployeeData;
using RestApiCRUDDemo.Models;

namespace RestApiCRUDDemo.Controllers
{
   
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeData _employeeDate;
        public EmployeeController(IEmployeeData employeeData)
        {
            _employeeDate = employeeData;
        }
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetEmployees()
        {
            var employees = _employeeDate.GetEmployees();
            return Ok(employees);
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult FindEmployee(Guid id)
        {
            var employee = _employeeDate.FindEmployee(id);
            if (employee != null)
            {
                return Ok(employee);
            }
            return NotFound($"Employee with Id: {id} was not found");
           
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddEmployee(Employee employee)
        {
           
            _employeeDate.AddEmployee(employee);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.Id, employee);
           

        }
        [HttpPatch]
        [Route("api/[controller]")]
        public IActionResult EditEmployee(Employee employee)
        {
            _employeeDate.EditEmployee(employee);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.Id, employee);



        }
        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteEmployee(Guid    id)
        {
           
            var employee = _employeeDate.FindEmployee(id);
            if (employee != null)
            {
                _employeeDate.DeleteEmployee(employee);
                return Ok();
            }
            return NotFound($"Employee with Id: {id} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult UpdateEmployee(Guid id,Employee employee)
        {

            var existingEmployee = _employeeDate.FindEmployee(id);
            if (existingEmployee != null)
            {
                employee.Id = existingEmployee.Id;
                _employeeDate.EditEmployee(employee);
                return Ok(employee);
            }
            return NotFound($"Employee with Id: {id} was not found");
        }
    }
}