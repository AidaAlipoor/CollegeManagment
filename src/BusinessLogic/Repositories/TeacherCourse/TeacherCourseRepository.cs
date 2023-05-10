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
using BusinessLogic.Repositories.Teacher;
using BusinessLogic.Repositories.Course;
using BusinessLogic.Repositories.Grade;

namespace BusinessLogic.Repositories.TeacherCourse
{
    internal class TeacherCourseRepository : Repository<TeacherCourseEntity>, ITeacherCourseRepository
    {
        public IReadOnlyList<int> InsertedIds { get; private set; }

        private readonly ITeacherRepository _teacherRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IGradeRepository _gradeRepository;

        public TeacherCourseRepository(
            ICollegeManagmentContext dbContext,
            ITeacherRepository teacherRepository, ICourseRepository courseRepository, IGradeRepository gradeRepository)
            : base(dbContext)
        {
            _teacherRepository = teacherRepository;
            _courseRepository = courseRepository;
            _gradeRepository = gradeRepository;
        }

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

        public override async Task DeleteAsync(int id)
        {
            await CheckDoesIdExistInTeacherCourse(id);
            await CheckIsTeacherCourseDeletable(id);

            await base.DeleteAsync(id);
        }
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
            await CheckDoesTeacherIdExist(teacherId);
            await CheckDoesCourseIdExist(courseId);

            var givenTeacherId = await _teacherRepository.FetchAsync(teacherId);
            var givenCourseId = await _courseRepository.FetchAsync(courseId);

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
            await CheckDoesTeacherIdExist(teacherId);
            await CheckDoesCourseIdExist(courseId);


            var teacherCourse = await FetchAsync(id);

            var givenTeacherId = await _teacherRepository.FetchAsync(teacherId);
            var givenCourseId = await _courseRepository.FetchAsync(courseId);

            teacherCourse.Teacher = givenTeacherId;
            teacherCourse.Course = givenCourseId;

            Update(teacherCourse);

        }
        public async Task<bool> AnyTeacher(int teacherId)
        {
            var teacherEntity = await _teacherRepository.FetchAsync(teacherId);
            return teacherEntity != null;
        }


        private async Task CheckDoesIdExistInTeacherCourse(int id)
        {
            var doesIdExistInTeacherCource = await FetchAsync(id);

            if (doesIdExistInTeacherCource == null)
                throw new Exception("this id does not exist");

        }
        private async Task CheckDoesTeacherIdExist(int teacherId)
        {
            var doesIdExistInTeacher = await _teacherRepository.FetchAsync(teacherId);

            if (doesIdExistInTeacher == null)
                throw new Exception("teacher id doesn't exist");
        }
        private async Task CheckDoesCourseIdExist(int courseId)
        {
            var doesIdExistInCource = await _courseRepository.FetchAsync(courseId);

            if (doesIdExistInCource == null)
                throw new Exception("course id doesn't exist");
        }
        private async Task CheckIsTeacherCourseDeletable(int teacherCourseId)
        {
            var isTeacherCourseUsedInGrade = await _gradeRepository.AnyTeacherCourse(teacherCourseId);

            if (isTeacherCourseUsedInGrade)
                throw new Exception("This item can not be deleted! ");
        }
    }
}
