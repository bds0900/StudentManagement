using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.GraphQL.Courses
{
    public record AddCourseInput(
        string CourseNumber, 
        string Description, 
        int Credit, 
        int Hourse, 
        string Grade,
        string GradePoint,
        string ProgramNumber
    );
}
