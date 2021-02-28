using HotChocolate;
using HotChocolate.Data;
using StudentManagement.Data;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        public IQueryable<Models.Program> GetPrograms([ScopedService] AppDbContext context)
        {
            return context.Programs;
        }
        [UseDbContext(typeof(AppDbContext))]
        public IQueryable<Course> GetCourses([ScopedService] AppDbContext context)
        {
            return context.Courses;
        }
        [UseDbContext(typeof(AppDbContext))]
        public IQueryable<Student> GetStudents([ScopedService] AppDbContext context)
        {
            return context.Students;
        }
        [UseDbContext(typeof(AppDbContext))]
        public IQueryable<Address> GetAddresses([ScopedService] AppDbContext context)
        {
            return context.Addresses;
        }
    }
}
