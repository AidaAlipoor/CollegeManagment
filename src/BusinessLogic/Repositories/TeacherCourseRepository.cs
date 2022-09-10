using System;
using System.Collections.Generic;
using TeacherCourse = DataAccess.Entities.TeacherCourse;
using System.Threading.Tasks;
using DataAccess.EntitiesConfiguration;
using System.Linq.Expressions;

namespace BusinessLogic.Repositories
{
    public class TeacherCourseRepository : Repository<TeacherCourse>
    {
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
        public override Task<List<TeacherCourse>> GetAsync()
        {
            return base.GetAsync();
        }
        public override Task<TeacherCourse> GetAsync(int id)
        {
            return base.GetAsync(id);
        }
        public override Task<List<TeacherCourse>> GetAsync(Expression<Func<TeacherCourse, bool>> predicate)
        {
            return base.GetAsync(predicate);
        }
    }
}
