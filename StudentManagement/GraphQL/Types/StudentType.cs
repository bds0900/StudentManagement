using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.GraphQL.Types
{
    public class StudentType : ObjectType<Student>
    {
        protected override void Configure(IObjectTypeDescriptor<Student> descriptor)
        {
            

            descriptor
                .Field(p => p.Courses)
                .ResolveWith<Resolvers>(p => p.GetCourses(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("get courses");
        }

        private class Resolvers
        {
            /*public Models.Program GetProgram(Student student, [ScopedService] AppDbContext context)
            {
                return student.Program;
            }*/

            public IQueryable<Course> GetCourses(Student student,[ScopedService]AppDbContext context)
            {
                return context.Courses.Include(c => c.CourseStudent).ThenInclude(cs => cs.StudentId == student.StudentId);
            }
        }
    }
}
