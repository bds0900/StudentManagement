using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Models.Program> Programs { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Address> Addresses { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Program>()
                .HasKey(p => p.ProgramId);
            modelBuilder.Entity<Course>()
                .HasKey(c => c.CourseId);
            modelBuilder.Entity<Student>()
                .HasKey(s => s.StudentId);
            modelBuilder.Entity<Address>()
                .HasKey(a => a.AddressId);
            modelBuilder.Entity<CourseStudent>()
                .HasKey(p => new { p.CourseId, p.StudentId });

            modelBuilder.Entity<Models.Program>()
                .Property(p => p.ProgramId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Course>()
                .Property(p => p.CourseId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Student>()
                .Property(p => p.StudentId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Address>()
                .Property(p => p.AddressId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Models.Program>()
                .HasMany(p => p.Students)
                .WithOne(p => p.Program);
            modelBuilder.Entity<Models.Program>()
                .HasMany(p => p.Courses)
                .WithOne(p => p.Program);
            modelBuilder.Entity<Student>()
                .HasOne(p => p.Address)
                .WithOne(p => p.Student)
                .HasForeignKey<Address>(p => p.StudentId);
            /*modelBuilder.Entity<Course>()
                .HasMany(c => c.Students)
                .WithMany(s => s.Courses)
                .UsingEntity<Dictionary<string, object>>(
                    "CourseStudent",
                    j => j
                    .HasOne<Student>()
                    .WithMany()
                    .HasForeignKey("StudentId")
                    .HasConstraintName("FK_CourseStudent_Students_StudentId")
                    .OnDelete(DeleteBehavior.Cascade),
                    j => j
                    .HasOne<Course>()
                    .WithMany()
                    .HasForeignKey("StudentId")
                    .HasConstraintName("FK_CourseStudent_Courses_CourseId")
                    .OnDelete(DeleteBehavior.Cascade)
                 );*/
            modelBuilder.Entity<Course>()
                .HasMany(p => p.Students)
                .WithMany(p => p.Courses)
                .UsingEntity<CourseStudent>(
                    j => j
                        .HasOne(p => p.Student)
                        .WithMany(p => p.CourseStudent)
                        .HasForeignKey(p => p.StudentId)
                        .HasConstraintName("FK_CourseStudent_Students_StudentId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j => j
                        .HasOne(p => p.Course)
                        .WithMany(p => p.CourseStudent)
                        .HasForeignKey(p => p.CourseId)
                        .HasConstraintName("FK_CourseStudent_Courses_CourseId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j =>
                    {
                        j.HasKey(t => new { t.CourseId, t.StudentId });
                    }
                );
        }
    }
}
