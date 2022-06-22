using RestApiCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestApiCRUD.EmployeeData
{
    public class MockEmployeeData : IEmployeeData
    {
        //hardcoding some mock data
        private List<Employee> employees = new List<Employee>()
        {
            new Employee()
            {
                Id = Guid.NewGuid(),
                Name = "Employee One"
            },

            new Employee()
            {
                Id = Guid.NewGuid(),
                Name = "Employee Two"
            }

        };

        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            employees.Add(employee);
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            employees.Remove(employee);
        }

        public Employee EditEmployee(Employee employee)
        {
            var existingEmployee = GetEmployee(employee.Id);
            existingEmployee.Name = employee.Name;
            return existingEmployee;
        }

        public Employee GetEmployee(Guid id)
        {
            //implementing the single return class if present or return error code according to controller
            return employees.SingleOrDefault(x => x.Id == id);
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }
    }
}
