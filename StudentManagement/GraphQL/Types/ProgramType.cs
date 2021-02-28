using HotChocolate;
using HotChocolate.Types;
using StudentManagement.Data;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.GraphQL.Types
{
    public class ProgramType:ObjectType<Models.Program>
    {
        protected override void Configure(IObjectTypeDescriptor<Models.Program> descriptor)
        {
            descriptor
                .Field(p => p.Courses)
                .ResolveWith<Resolvers>(r => r.GetCourses(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("get courses");
            descriptor
                .Field(p => p.Students)
                .ResolveWith<Resolvers>(r => r.GetStudents(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("get students");
        }

        private class Resolvers
        { 
            public IQueryable<Student> GetStudents(Models.Program program,[ScopedService]AppDbContext context)
            {
                return context.Students.Where(s => s.ProgramId == program.ProgramId);
            }
            public IQueryable<Course> GetCourses(Models.Program program, [ScopedService] AppDbContext context)
            {
                return context.Courses.Where(c => c.ProgramId == program.ProgramId);
            }
        }

    }
}
