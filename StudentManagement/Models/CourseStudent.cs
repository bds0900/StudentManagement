using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    //https://docs.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key#join-entity-type-configuration
    //custom join entity type
    public class CourseStudent
    {
        public string CourseId { get; set; }
        public Course Course { get; set; }

        public string StudentId { get; set; }
        public Student Student { get; set; }
    }
}
