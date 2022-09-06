using DataAccess.Entities;
using DataAccess.EntitiesConfiguration;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using CourseEntity = DataAccess.Entities.Course;
using StudentEntity = DataAccess.Entities.Student;
using TeacherEntity = DataAccess.Entities.Teacher;

namespace DataAccess.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<CollegeManagmentContext>
    {
        public Configuration() => AutomaticMigrationsEnabled = false;

        protected override void Seed(CollegeManagmentContext context)
        {
            var courses = new List<CourseEntity>
            {
                new CourseEntity { CourseName = "gossaste" },
                new CourseEntity { CourseName = "Madar Manteghi" }

            };

            var students = new List<StudentEntity>
            {
                new StudentEntity
                {
                    StudentName = Faker.Name.First(),
                    StudentLastName = Faker.Name.Last(),
                    IdNumber = Faker.RandomNumber.Next()
                },
                new StudentEntity
                {
                    StudentName = Faker.Name.First(),
                    StudentLastName = Faker.Name.Last(),
                    IdNumber = Faker.RandomNumber.Next()
                }
            };

            var teachers = new List<TeacherEntity>
            {
                new TeacherEntity
                {
                    TeacherName = Faker.Name.First(),
                    TeacherLastName = Faker.Name.Last(),
                    Birthday = DateTime.Now.Date
                },
                new TeacherEntity
                {
                    TeacherName = Faker.Name.First(),
                    TeacherLastName = Faker.Name.Last(),
                    Birthday = DateTime.Now.Date
                }
             };

            context.Courses.AddRange(courses);
            context.Students.AddRange(students);
            context.Teachers.AddRange(teachers);

            context.SaveChanges();
        }


    }
}

