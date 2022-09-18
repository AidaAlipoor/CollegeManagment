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

namespace BusinessLogic.Repositories
{
    public class GradeRepository : Repository<GradeEntity> , IGradeRepository
    {
        public IReadOnlyList<int> InsertedIds { get; private set; }

        public override void Add(GradeEntity entity)
        {
            if (!IsGradeValid(entity))
                throw new Exception();

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

        public override Task DeleteAsync(int id)
        {
            return base.DeleteAsync(id);
        }
        public override Task<List<GradeEntity>> FetchAsync()
        {
            return base.FetchAsync();
        }
        public override Task<GradeEntity> FetchAsync(int id)
        {
            return base.FetchAsync(id);
        }
        public override Task<List<GradeEntity>> FetchAsync(Expression<Func<GradeEntity, bool>> predicate)
        {
            return base.FetchAsync(predicate);
        }

        private bool IsGradeValid(GradeEntity entity) =>  IsGradeValueValid(entity.Score);
        private bool IsGradeValueValid(int score)
        {
            return score >= 0 && score <= GradeEntity.ScoreNumberLimit;
        }

        public async Task<List<GradeViewModel>> GetAsync()
        {
            return await dbContext.Grades
                .Select(g => new GradeViewModel 
                { 
                    Id = g.Id, Score = g.Score,
                    TeacherCourseId = g.TeacherCourse.Id, 
                    StudentId = g.Students.Id 
                
                }).ToListAsync();
        }

        public void Insert(string name)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, string name)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
