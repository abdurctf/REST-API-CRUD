using RestApiCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestApiCRUD.EmployeeData
{
    public class SqlEmployeeData : IEmployeeData
    {
        //declare private employeeContext at first then declare constructor to get the employeeContext
        private EmployeeContext _employeeContext;

        public SqlEmployeeData(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        

        public Employee AddEmployee(Employee employee)
        {
            _employeeContext.Employees.Add(employee);
            _employeeContext.SaveChanges();
            return employee;

        }

        public void DeleteEmployee(Employee employee)
        {
            //we are already fetching the employee to be deleted so we do not
            //need to find it anymore
            _employeeContext.Employees.Remove(employee);
            _employeeContext.SaveChanges();
        }

        public Employee EditEmployee(Employee employee)
        {
            //we already fetched the user in controller, why are we fetching it again?
            //or else there is a Id conflict error
            var existingEmployee = _employeeContext.Employees.Find(employee.Id);
            if(existingEmployee != null)
            {
                
                _employeeContext.Employees.Update(existingEmployee);
                _employeeContext.SaveChanges();
            }
            return employee;

        }

        public Employee GetEmployee(Guid id)
        {
            var employee = _employeeContext.Employees.Find(id);
            return employee;
        }

        public List<Employee> GetEmployees()
        {
            return _employeeContext.Employees.ToList();
        }
    }
}
