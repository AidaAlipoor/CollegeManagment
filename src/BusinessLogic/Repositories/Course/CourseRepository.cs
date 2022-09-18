
using BusinessLogic.Repositories.Repositorey;
using BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CourseEntity = DataAccess.Entities.Course;

namespace BusinessLogic.Repositories.Course
{
    public class CourseRepository : Repository<CourseEntity> , ICourseRepository
    {
        public IReadOnlyList<int> InsertedIds { get; private set; }

        public override void Add(CourseEntity entity)
        {
            ValidCourse(entity);

            base.Add(entity);
        }
        public override void Delete(CourseEntity entity)
        {
            CheckIsCourseDeletable(entity);
            base.Delete(entity);
        }
        public override void Update(CourseEntity entity)
        {
            ValidCourse(entity);
            base.Update(entity);
        }

        public override Task DeleteAsync(int id)
        {
            return base.DeleteAsync(id);
        }
        public override Task<List<CourseEntity>> FetchAsync()
        {
            return base.FetchAsync();
        }
        public override Task<CourseEntity> FetchAsync(int id)
        {
            return base.FetchAsync(id);
        }
        public override Task<List<CourseEntity>> FetchAsync(Expression<Func<CourseEntity, bool>> predicate)
        {
            return base.FetchAsync(predicate);
        }


        public override async Task SaveAsync()
        {
            var addedEntities = dbContext.ChangeTracker
                .Entries<CourseEntity>()
                .Where(t => t.State == EntityState.Added)
                .ToArray();

            await base.SaveAsync();

            InsertedIds = addedEntities.Select(t => t.Entity.Id).ToList();
        }

        public async Task<List<CourseViewModel>> GetAsync()
        {
            return await dbContext.Courses
                .Select(c => new CourseViewModel 
                {
                    Id = c.Id,
                    Name = c.CourseName 
                })
                .ToListAsync();

        }

        public void Insert(string name)
        {
            var course = new CourseEntity{ CourseName = name};
            Add(course);
        }

        public async Task UpdateAsync(int id, string name)
        {
            CheckDoesIdExist(id);

           var course = await FetchAsync(id);

            course.CourseName = name;

            Update(course);
        }

        public async Task Delete(int id)
        {
            CheckDoesIdExist(id);

            var courseEntity = await FetchAsync(id);

            Delete(courseEntity);
        }


        private void ValidCourse(CourseEntity entity)
        {
            if (IsCourseNameEmpty(entity.CourseName) || !IsLetter(entity.CourseName))
                throw new Exception("Name is invalid");
        } 
        private bool IsCourseNameEmpty(string name) => string.IsNullOrEmpty(name);
        private bool IsLetter(string name) => int.TryParse(name , out _);
        private void CheckIsCourseDeletable(CourseEntity entity)
        {
            var isCourseUsedAtTeacherCourses = dbContext.TeacherCourses
                .Include(tc => tc.Course)
                .Any(tc => tc.Course.Id == entity.Id);

            if (isCourseUsedAtTeacherCourses)
                throw new Exception("this item can not be deleted!");
        }
        private void CheckDoesIdExist(int id)
        {
            var doesIdExistInCourse = dbContext.Courses.Any(t => t.Id == id);

            if (!doesIdExistInCourse)
                throw new Exception("this id does not exist");

        }

    }
}
