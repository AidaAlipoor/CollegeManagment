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
        public IReadOnlyList<int> InsertedIds => throw new NotImplementedException();

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

        public void Insert(string name, string lastname, DateTime birthday)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, string name, string lastname, DateTime birthday)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        
    }
}
