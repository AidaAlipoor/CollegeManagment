
using DataAccess.EntitiesConfiguration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CourseEntity = DataAccess.Entities.Course;

namespace BusinessLogic.Repositories
{
    public class CourseRepository : Repository<CourseEntity>
    {
        public override void Add(CourseEntity entity)
        {
            if (!IsCourseValid(entity))
                throw new Exception();

            base.Add(entity);
        }
        public override void Delete(CourseEntity entity)
        {
            CheckIsCourseDeletable(entity);
            base.Delete(entity);
        }
        public override void Update(CourseEntity entity)
        {
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

        private bool IsCourseValid(CourseEntity entity) => !IsCourseNameEmpty(entity.CourseName) && !IsLetter(entity.CourseName);
        private bool IsCourseNameEmpty(string name) => string.IsNullOrEmpty(name);
        private bool IsLetter(string name) => int.TryParse(name , out _);
        private void CheckIsCourseDeletable(CourseEntity entity)
        {
            var isCourseUsedAtTeacherCourses = dbContext.TeacherCourses
                .Include(tc => tc.Course)
                .Any(tc => tc.Course.Id == entity.Id);

            if (isCourseUsedAtTeacherCourses)
                throw new Exception();
        }
    }
}
