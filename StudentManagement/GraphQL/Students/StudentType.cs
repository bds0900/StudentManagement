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

namespace StudentManagement.GraphQL.Students
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
            descriptor
                .Field(p => p.Program)
                .ResolveWith<Resolvers>(p => p.GetProgram(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("get program info");
        }

        private class Resolvers
        {
            public Models.Program GetProgram(Student student, [ScopedService] AppDbContext context)
            {
                return context.Programs.Where(p=>p.ProgramId==student.ProgramId).FirstOrDefault();
            }

            public IQueryable<Course> GetCourses(Student student,[ScopedService]AppDbContext context)
            {
                return context.Courses.Include(c => c.CourseStudent).ThenInclude(cs => cs.StudentId == student.StudentId);
            }

        }
    }
}
