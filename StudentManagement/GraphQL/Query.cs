﻿using HotChocolate;
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
        [UseFiltering]
        [UseSorting]
        public IQueryable<Models.Program> GetPrograms([ScopedService] AppDbContext context)
        {
            return context.Programs;
        }
        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Course> GetCourses([ScopedService] AppDbContext context)
        {
            return context.Courses;
        }
        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Student> GetStudents([ScopedService] AppDbContext context)
        {
            return context.Students;
        }
        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Address> GetAddresses([ScopedService] AppDbContext context)
        {
            return context.Addresses;
        }

        [UseDbContext(typeof(AppDbContext))]
        public Models.Program GetProgramByNumber([ScopedService] AppDbContext context, string programNumber)
        {
            return context.Programs.Where(p=>p.ProgramNumber==programNumber).FirstOrDefault();
        }
        [UseDbContext(typeof(AppDbContext))]
        public Course GetCourseByNumber([ScopedService] AppDbContext context,string courseNumber)
        {
            return context.Courses.Where(c=>c.CourseNumber==courseNumber).FirstOrDefault();
        }
        [UseDbContext(typeof(AppDbContext))]
        public Student GetStudentByNumber([ScopedService] AppDbContext context,string studentNumber)
        {
            return context.Students.Where(s=>s.StudentNumber==studentNumber).FirstOrDefault();
        }
    }
}
