using BusinessLogic.Repositories.Repositorey;
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
    public class GradeRepository : Repository<GradeEntity>, IGradeRepository
    {
        public GradeRepository(ICollegeManagmentContext dbcontext) : base(dbcontext) { }

        public IReadOnlyList<int> InsertedIds { get; private set; }

        public override void Add(GradeEntity entity)
        {
            ValidGradeValue(entity.Score);
            CheckDoTeacherCourceIdAndStuentIdExist(entity.TeacherCourse.Id, entity.Students.Id);

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
            var givenTeacherCourseId = await _dbContext.Set<DataAccess.Entities.TeacherCourse>().FindAsync(teacherCourseId);
            var givenStudentId = await _dbContext.Set<DataAccess.Entities.Student>().FindAsync(studentId);

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
            CheckDoTeacherCourceIdAndStuentIdExist(teacherCourseId, studentId);

            var gradeId = await FetchAsync(id);
            var givenTeacherCourseId = await _dbContext.Set<DataAccess.Entities.TeacherCourse>().FindAsync(teacherCourseId);
            var givenStudentId = await _dbContext.Set<DataAccess.Entities.Student>().FindAsync(studentId);

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
            var gradeId = _dbContext.Set<GradeEntity>().Any(g => g.Id == id);

            if (!gradeId)
                throw new Exception("This id does not exist");
        }
        private void CheckDoTeacherCourceIdAndStuentIdExist(int teacherCourseId, int studentId)
        {
            var doesIdExistInTeacherCourse = _dbContext.Set<DataAccess.Entities.TeacherCourse>().Any(tc => tc.Id == teacherCourseId);
            var doesIdExistInStudent = _dbContext.Set<DataAccess.Entities.Student>().Any(s => s.Id == studentId);

            if (!doesIdExistInTeacherCourse && !doesIdExistInStudent)
                throw new Exception("teacherCourse id or Student id doesn't exist");
        }

    }
}
