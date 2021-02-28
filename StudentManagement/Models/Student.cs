using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class Student
    {
        [Key]
        public string StudentId { get; set; }
        [Required]
        public string StudentNumber { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public Address Address { get; set; }
        


        public string ProgramId { get; set; }
        public Models.Program Program { get; set; }


        public ICollection<Course> Courses { get; set; }
        public List<CourseStudent> CourseStudent { get; set; }


    }
}
