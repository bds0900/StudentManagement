using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    [Index(nameof(CourseNumber), IsUnique = true)]
    public class Course
    {
        [Key]
        public string CourseId { get; set; }
        [Required]
        public string CourseNumber { get; set; }
        public string Description { get; set; }
        [Required]
        public int Credits { get; set; }
        [Required]
        public int Hours { get; set; }
                


        public string ProgramId { get; set; }
        public Models.Program Program { get; set; }

        public ICollection<Student> Students { get; set; }
        public List<CourseStudent> CourseStudent { get; set; }
    }
}
