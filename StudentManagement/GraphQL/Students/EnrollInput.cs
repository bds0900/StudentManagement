using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.GraphQL.Students
{
    public record EnrollInput(
        string StudentNumber,
        string CourseNumber
    );
    
}
