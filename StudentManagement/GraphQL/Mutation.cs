﻿using HotChocolate;
using HotChocolate.Data;
using StudentManagement.Data;
using StudentManagement.GraphQL.Courses;
using StudentManagement.GraphQL.Programs;
using StudentManagement.GraphQL.Students;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<Models.Program> AddProgramAsync(AddProgramInput input, [ScopedService] AppDbContext context)
        {
            var program = new Models.Program
            {
                ProgramName = input.ProgramName,
                ProgramNumber = input.ProgramNumber
            };
            await context.Programs.AddAsync(program);
            await context.SaveChangesAsync();
            return program;
        }
        [UseDbContext(typeof(AppDbContext))]
        public async Task<Course> AddCourseAsync(AddCourseInput input,[ScopedService] AppDbContext context)
        {
            var programId = context.Programs.Where(p => p.ProgramNumber == input.ProgramNumber).Select(p => p.ProgramId).FirstOrDefault();

            var course = new Course
            {
                CourseNumber = input.CourseNumber,
                Credits = input.Credit,
                Hours = input.Hourse,
                ProgramId = programId,
            };
            await context.Courses.AddAsync(course);
            await context.SaveChangesAsync();
            return course;
        }
        [UseDbContext(typeof(AppDbContext))]
        public async Task<Student> AddStudentAsync(AddStudentInput input,[ScopedService] AppDbContext context)
        {
            Random r = new Random();
            var programId = context.Programs.Where(p => p.ProgramNumber == input.ProgramNumber).Select(p=>p.ProgramId).FirstOrDefault();
            var student = new Student
            {
                StudentNumber=r.Next(10,50).ToString(),
                FirstName = input.FirstName,
                LastName = input.LastName,
                Email = input.Email,
                PhoneNumber = input.PhoneNumber,
                Address = input.Address,
                ProgramId = programId,
            };
            await context.Students.AddAsync(student);
            await context.SaveChangesAsync();
            return student;

        }
    }
}