//this is where the rest api functions will be kept
using RestApiCRUD.Models;
using System;
using System.Collections.Generic;

namespace RestApiCRUD.EmployeeData
{
    public interface IEmployeeData
    {
        //this will return a list of the employees
        List<Employee> GetEmployees();

        //will represent an employee
        Employee GetEmployee(Guid id);

        //will add an employee
        Employee AddEmployee (Employee employee);

        //will return the updated employee
        Employee EditEmployee (Employee employee);

        //since deleting will return nothing
        void DeleteEmployee (Employee id);
    }
}
