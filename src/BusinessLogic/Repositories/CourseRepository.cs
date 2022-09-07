
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
        public CourseRepository(CollegeManagmentContext dbContext)
           : base(dbContext) { }

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
        public override Task<List<CourseEntity>> GetAsync()
        {
            return base.GetAsync();
        }
        public override Task<CourseEntity> GetAsync(int id)
        {
            return base.GetAsync(id);
        }
        public override Task<List<CourseEntity>> GetAsync(Expression<Func<CourseEntity, bool>> predicate)
        {
            return base.GetAsync(predicate);
        }

        private bool IsCourseValid(CourseEntity entity) => !IsCourseNameEmpty(entity.CourseName) && IsLetter(entity.CourseName);
        private bool IsCourseNameEmpty(string name) => string.IsNullOrEmpty(name);
        private bool IsLetter(string name) => name.Count(c => char.IsLetter(c)) == name.Length;
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
