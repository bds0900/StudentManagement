using HotChocolate;
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
        public IQueryable<Models.Program> GetPrograms([Service] AppDbContext context)
        {
            return context.Programs;
        }
        public IQueryable<Course> GetCourses([Service] AppDbContext context)
        {
            return context.Courses;
        }
        public IQueryable<Student> GetStudents([Service] AppDbContext context)
        {
            return context.Students;
        }
        public IQueryable<Address> GetAddresses([Service] AppDbContext context)
        {
            return context.Addresses;
        }
    }
}
