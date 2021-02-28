using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class Program
    {
        [Key]
        public string ProgramId { get; set; }
        [Required]
        public string ProgramName { get; set; }
        [Required]
        public string ProgramNumber { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Course> Courses { get; set; }

    }
}
