using BusinessLogic.Repositories.Repositorey;
using BusinessLogic.Repositories.Student;
using BusinessLogic.Repositories.TeacherCourse;
using BusinessLogic.ViewModels;
using DataAccess.EntitiesConfiguration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GradeEntity = DataAccess.Entities.Grade;

namespace BusinessLogic.Repositories.Grade
{
    internal class GradeRepository : Repository<GradeEntity>, IGradeRepository
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ITeacherCourseRepository _teacherCourseRepository;
        public GradeRepository(
            ICollegeManagmentContext dbcontext
            , IStudentRepository studentRepository , ITeacherCourseRepository teacherCourseRepository)
            : base(dbcontext)
        {
            _studentRepository = studentRepository;
            _teacherCourseRepository = teacherCourseRepository;
        }

        public IReadOnlyList<int> InsertedIds { get; private set; }

        public override void Add(GradeEntity entity)
        {
            ValidGradeValue(entity.Score);

            base.Add(entity);
        }
        public override void Delete(GradeEntity entity)
        {
            base.Delete(entity);
        }
        public override void Update(GradeEntity entity)
        {
            base.Update(entity);
        }

        public override async Task DeleteAsync(int id) => await base.DeleteAsync(id);
        public override async Task<List<GradeEntity>> FetchAsync() => await base.FetchAsync();
        public override async Task<GradeEntity> FetchAsync(int id) => await base.FetchAsync(id);
        public override async Task<List<GradeEntity>> FetchAsync(Expression<Func<GradeEntity, bool>> predicate) => await base.FetchAsync(predicate);


        public override async Task SaveAsync()
        {
            var addedEntities = _dbContext.ChangeTracker
                .Entries<GradeEntity>()
                .Where(g => g.State == EntityState.Added)
                .ToArray();

            await base.SaveAsync();

            InsertedIds = addedEntities.Select(g => g.Entity.Id).ToList();
        }
        public async Task<List<GradeViewModel>> GetAsync()
        {
            return await _dbContext.Set<GradeEntity>()
                .Select(g => new GradeViewModel
                {
                    Id = g.Id,
                    Score = g.Score,
                    TeacherCourseId = g.TeacherCourse.Id,
                    StudentId = g.Students.Id

                }).ToListAsync();
        }
        public async Task Insert(int score, int teacherCourseId, int studentId)
        {
            CheckDoesTeacherCourceIdExist(teacherCourseId);
            CheckDoesStudentIdExist(studentId);

            var givenTeacherCourseId = await _teacherCourseRepository.FetchAsync(teacherCourseId);
            var givenStudentId = await _studentRepository.FetchAsync(studentId);

            var grade = new GradeEntity
            {
                Score = score,
                TeacherCourse = givenTeacherCourseId,
                Students = givenStudentId
            };

            Add(grade);

        }
        public async Task UpdateAsync(int id, int score, int teacherCourseId, int studentId)
        {
            CheckDoesIdExistInGrade(id);
            CheckDoesTeacherCourceIdExist(teacherCourseId);
            CheckDoesStudentIdExist(studentId);

            var gradeId = await FetchAsync(id);
            var givenTeacherCourseId = await _teacherCourseRepository.FetchAsync(teacherCourseId);
            var givenStudentId = await _studentRepository.FetchAsync(studentId);

            gradeId.Score = score;
            gradeId.TeacherCourse = givenTeacherCourseId;
            gradeId.Students = givenStudentId;

            Update(gradeId);
        }
        public async Task Delete(int id)
        {
            CheckDoesIdExistInGrade(id);

            var gradeId = await _dbContext.Set<GradeEntity>().FindAsync(id);

            Delete(gradeId);
        }


        private void ValidGradeValue(int score)
        {
            var scoreValueLimte = score >= 0 && score <= GradeEntity.ScoreNumberLimit;

            if (!scoreValueLimte)
                throw new Exception("score is not valid!");
        }
        private void CheckDoesIdExistInGrade(int id)
        {
            var gradeId = FetchAsync(id);

            if (gradeId == null)
                throw new Exception("This id does not exist");
        }
        private void CheckDoesTeacherCourceIdExist(int teacherCourseId)
        {
            var doesIdExistInTeacherCourse = _teacherCourseRepository.FetchAsync(teacherCourseId);

            if (doesIdExistInTeacherCourse == null)
                throw new Exception("teacherCourse id doesn't exist");
        }
        private void CheckDoesStudentIdExist(int studentId)
        {
            var doesIdExistInStudent = _studentRepository.FetchAsync(studentId);

            if (doesIdExistInStudent == null)
                throw new Exception("student id doesn't exist");
        }


    }
}
