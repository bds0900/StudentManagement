using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class Course
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string CourseNumber { get; set; }
        public string Description { get; set; }
        [Required]
        public int Credits { get; set; }
        [Required]
        public int Hours { get; set; }
        [Required]
        public string Grade { get; set; }
        [Required]
        public string GradePoint { get; set; }
        


        public string ProgramId { get; set; }
        public Program Program { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
