using System;
using System.Collections.Generic;
using TeacherCourseEntity = DataAccess.Entities.TeacherCourse;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Linq;
using BusinessLogic.ViewModels;
using System.Data.Entity;
using BusinessLogic.Repositories.Repositorey;
using DataAccess.EntitiesConfiguration;

namespace BusinessLogic.Repositories.TeacherCourse
{
    public class TeacherCourseRepository : Repository<TeacherCourseEntity>, ITeacherCourseRepository
    {
        public IReadOnlyList<int> InsertedIds { get; private set; }

        public TeacherCourseRepository(ICollegeManagmentContext dbContext) : base(dbContext) { }

        public override void Add(TeacherCourseEntity entity)
        {
            base.Add(entity);
        }
        public override void Delete(TeacherCourseEntity entity)
        {
            base.Delete(entity);
        }
        public override void Update(TeacherCourseEntity entity)
        {
            base.Update(entity);
        }

        public override async Task DeleteAsync(int id) => await base.DeleteAsync(id);
        public override async Task<List<TeacherCourseEntity>> FetchAsync() => await base.FetchAsync();
        public override async Task<TeacherCourseEntity> FetchAsync(int id) => await base.FetchAsync(id);
        public override async Task<List<TeacherCourseEntity>> FetchAsync(Expression<Func<TeacherCourseEntity, bool>> predicate)
            => await base.FetchAsync(predicate);



        public override async Task SaveAsync()
        {
            var addedEntities = _dbContext.ChangeTracker
                .Entries<TeacherCourseEntity>()
                .Where(t => t.State == EntityState.Added)
                .ToArray();

            await base.SaveAsync();

            InsertedIds = addedEntities.Select(t => t.Entity.Id).ToList();
        }
        public async Task<List<TeacherCourseViewModel>> GetAsync()
        {
            return await _dbContext.Set<TeacherCourseEntity>()
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
            await CheckDoTeacherIdAndCourceIdExist(teacherId, courseId);

            var givenTeacherId = await _dbContext.Set<DataAccess.Entities.Teacher>().FindAsync(teacherId);
            var givenCourseId = await _dbContext.Set<DataAccess.Entities.Course>().FindAsync(courseId);

            var teacherCourse = new TeacherCourseEntity
            {
                Teacher = givenTeacherId,
                Course = givenCourseId
            };

            Add(teacherCourse);
        }
        public async Task UpdateAsync(int id, int teacherId, int courseId)
        {
            await CheckDoesIdExistInTeacherCourse(id);
            await CheckDoTeacherIdAndCourceIdExist(teacherId, courseId);

            var teacherCourse = await FetchAsync(id);

            var givenTeacherId = await _dbContext.Set<DataAccess.Entities.Teacher>().FindAsync(teacherId);
            var givenCourseId = await _dbContext.Set < DataAccess.Entities.Course>().FindAsync(courseId);

            teacherCourse.Teacher = givenTeacherId;
            teacherCourse.Course = givenCourseId;

            Update(teacherCourse);

        }
        public async Task Delete(int id)
        {
            await CheckDoesIdExistInTeacherCourse(id);

            var teacherCourse = await FetchAsync(id);

            Delete(teacherCourse);
        }


        private async Task CheckDoesIdExistInTeacherCourse(int id)
        {
            var doesIdExistInTeacherCource = await _dbContext.Set<TeacherCourseEntity>().AnyAsync(tc => tc.Id == id);

            if (!doesIdExistInTeacherCource)
                throw new Exception("this id does not exist");

        }
        private async Task CheckDoTeacherIdAndCourceIdExist(int teacherId, int courseId)
        {
            var doesIdExistInTeacher = await _dbContext.Set<DataAccess.Entities.Teacher>().AnyAsync(tc => tc.Id == teacherId);
            var doesIdExistInCource = await _dbContext.Set<DataAccess.Entities.Course>().AnyAsync(tc => tc.Id == courseId);

            if (!doesIdExistInTeacher && !doesIdExistInCource)
                throw new Exception("teacher id or course id doesn't exist");
        }
    }
}
