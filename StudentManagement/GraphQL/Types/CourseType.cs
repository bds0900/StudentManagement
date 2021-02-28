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
    public class CourseType:ObjectType<Course>
    {
        protected override void Configure(IObjectTypeDescriptor<Course> descriptor)
        {
            descriptor
                .Field(p => p.Students)
                .ResolveWith<Resolvers>(r => r.GetStudents(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("get students");
        }

        private class Resolvers
        { 
            public IQueryable<Student> GetStudents(Course course,[ScopedService]AppDbContext context)
            {
                return context.Students.Include(s => s.CourseStudent).ThenInclude(cs => cs.CourseId==course.CourseId);
            }
        }

    }
}
