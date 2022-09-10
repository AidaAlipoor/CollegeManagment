using DataAccess.EntitiesConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GradeEntity = DataAccess.Entities.Grade;

namespace BusinessLogic.Repositories
{
    public class GradeRepository : Repository<GradeEntity>
    {
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
        public override Task<List<GradeEntity>> GetAsync()
        {
            return base.GetAsync();
        }
        public override Task<GradeEntity> GetAsync(int id)
        {
            return base.GetAsync(id);
        }
        public override Task<List<GradeEntity>> GetAsync(Expression<Func<GradeEntity, bool>> predicate)
        {
            return base.GetAsync(predicate);
        }

        private bool IsGradeValid(GradeEntity entity) =>  IsGradeValueValid(entity.Score);
        private bool IsGradeValueValid(int score)
        {
            return score >= 0 && score <= GradeEntity.ScoreNumberLimit;
        }

    }
}
