using System;
using System.Collections.Generic;
using TeacherCourse = DataAccess.Entities.TeacherCourse;
using System.Threading.Tasks;
using DataAccess.EntitiesConfiguration;
using System.Linq.Expressions;
using System.Linq;
using BusinessLogic.ViewModels;
using System.Data.Entity;

namespace BusinessLogic.Repositories
{
    public class TeacherCourseRepository : Repository<TeacherCourse> , ITeacherCourseRepository
    {
        public IReadOnlyList<int> InsertedIds { get; private set; }

        public TeacherCourseRepository() : base() { }

        public override void Add(TeacherCourse entity)
        {
            base.Add(entity);
        }
        public override void Delete(TeacherCourse entity)
        {
            base.Delete(entity);
        }
        public override void Update(TeacherCourse entity)
        {
            base.Update(entity);
        }

        public override Task DeleteAsync(int id)
        {
            return base.DeleteAsync(id);
        }
        public override Task<List<TeacherCourse>> FetchAsync()
        {
            return base.FetchAsync();
        }
        public override Task<TeacherCourse> FetchAsync(int id)
        {
            return base.FetchAsync(id);
        }
        public override Task<List<TeacherCourse>> FetchAsync(Expression<Func<TeacherCourse, bool>> predicate)
        {
            return base.FetchAsync(predicate);
        }



        public override async Task SaveAsync()
        {
            var addedEntities = dbContext.ChangeTracker
                .Entries<TeacherCourse>()
                .Where(t => t.State == EntityState.Added)
                .ToArray();

            await base.SaveAsync();

            InsertedIds = addedEntities.Select(t => t.Entity.Id).ToList();
        }
        public async Task<List<TeacherCourseViewModel>> GetAsync()
        {
            return await dbContext.TeacherCourses
                .Select(tc => new TeacherCourseViewModel 
                { 
                    Id = tc.Id, 
                    CourseId = tc.Course.Id, 
                    TeacherId = tc.Teacher.Id
                
                })
                .ToListAsync();
        }
        public async Task Insert(int teacherId, int courseId)
        {
            CheckDoTeacherIdAndCourceIdExist(teacherId, courseId);

            var givenTeacherId = await dbContext.Teachers.FindAsync(teacherId);
            var givenCourseId = await dbContext.Courses.FindAsync(courseId);

            var teacherCourse = new TeacherCourse 
            {
                Teacher = givenTeacherId,
                Course = givenCourseId 
            };

            Add(teacherCourse);
        }
        public async Task UpdateAsync(int id, int teacherId, int courseId)
        {
             CheckDoesIdExistInTeacherCourse(id);
             CheckDoTeacherIdAndCourceIdExist(teacherId, courseId);

            var teacherCourse = await FetchAsync(id);

            var givenTeacherId = await dbContext.Teachers.FindAsync(teacherId);
            var givenCourseId = await dbContext.Courses.FindAsync(courseId);

            teacherCourse.Teacher = givenTeacherId;
            teacherCourse.Course = givenCourseId;

            Update(teacherCourse);
           
        }
        public async Task Delete(int id)
        {
            CheckDoesIdExistInTeacherCourse(id);

            var teacherCourse = await FetchAsync(id);

            Delete(teacherCourse);
        }


        private void CheckDoesIdExistInTeacherCourse(int id)
        {
            var doesIdExistInTeacherCource = dbContext.TeacherCourses.Any(tc => tc.Id == id);

            if (!doesIdExistInTeacherCource)
                throw new Exception("this id does not exist");

        }
        private void CheckDoTeacherIdAndCourceIdExist(int teacherId, int courseId)
        {
            var doesIdExistInTeacher = dbContext.Teachers.Any(tc => tc.Id == teacherId);
            var doesIdExistInCource = dbContext.Courses.Any(tc => tc.Id == courseId);

            if (!doesIdExistInTeacher && !doesIdExistInCource)
                throw new Exception("teacher id or course id doesn't exist");
        }
    }
}
