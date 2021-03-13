using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.GraphQL.Students
{
    public record AddStudentInput(
        string FirstName,
        string LastName,
        string Email, 
        string PhoneNumber,
        Address Address,
        string ProgramNumber
    );
}
