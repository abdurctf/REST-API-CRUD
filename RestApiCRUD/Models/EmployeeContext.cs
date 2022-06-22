using Microsoft.EntityFrameworkCore;

namespace RestApiCRUD.Models
{
    //inherit the DbContext from MS EntFram
    public class EmployeeContext: DbContext
    {
        //then create a constructor using ctor and use DbContext options of type EmployeeContext and 
        //pass to base constructor 
        public EmployeeContext(DbContextOptions<EmployeeContext>options): base(options)
        {
            
        }

        //also create a DbSet property of the employee model and call this Employees
        //so this is basically acting as a table, Employees table
        public DbSet<Employee> Employees { get; set; }
    }

}
