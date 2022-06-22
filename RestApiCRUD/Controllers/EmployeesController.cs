using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiCRUD.EmployeeData;
using RestApiCRUD.Models;
using System;

namespace RestApiCRUD.Controllers
{
    
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        //injecting the employee data
        private IEmployeeData _employeeData;
        public EmployeesController(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }
        
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetEmployees()
        {
            //needed to wrap it in an Ok object since passing data back and need a success statement
            return Ok(_employeeData.GetEmployees());
        }

        //returning a single employee
        
        [HttpGet]
        [Route("api/[controller]/{id}")]

        public IActionResult GetEmployee(Guid id)
        {
            var employee = _employeeData.GetEmployee(id);

            if (employee != null)
            {
                return Ok(employee);
            }

            return NotFound($"Employee {id} not found");

        }
        //adding an employee in the database
        [HttpPost]
        [Route("api/[controller]")]

        public IActionResult GetEmployee(Employee employee)
        {
            _employeeData.AddEmployee(employee);

            return Created(HttpContext.Request.Scheme+ "://"+ HttpContext.Request.Host+
                HttpContext.Request.Path+ "/"+ employee.Id, employee);

        }

        //deleting an employee from the list
        [HttpDelete]
        [Route("api/[controller]/{id}")]

        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = _employeeData.GetEmployee(id);
            if (employee != null)
            {
                _employeeData.DeleteEmployee(employee);
                return Ok();
            }

            return NotFound($"Employee {id} not found");
            //once declaring the delete method is done then implement it in the mock data file

        }

        //editing an existing user
        [HttpPatch]
        [Route("api/[controller]/{id}")]

        public IActionResult EditEmployee(Guid id, Employee employee)
        {
           var existingEmployee = _employeeData.GetEmployee(id);
            if(existingEmployee != null)
            {
                employee.Id = existingEmployee.Id;
                _employeeData.EditEmployee(employee);
            }

            return Ok(employee);
            //then just like last time implement in mock data file
        }
    }
}
