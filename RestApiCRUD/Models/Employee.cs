using System;
using System.ComponentModel.DataAnnotations;

namespace RestApiCRUD.Models
{
    public class Employee
    {   
        //setting as key for the Employees table to be stored in database
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage ="Name must be within 50 characters")]
        public string Name { get; set; }
    }
}
