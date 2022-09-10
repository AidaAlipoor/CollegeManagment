using DataAccess.EntitiesConfiguration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TeacherEntity = DataAccess.Entities.Teacher;

namespace BusinessLogic.Repositories
{
    public class TeacherRepository : Repository<TeacherEntity> 
    {
        public TeacherRepository() : base(CollegeManagmentContext.GetInstance()) { }

        public override void Add(TeacherEntity entity)
        {
            if (!IsTeacherValid(entity))
                throw new Exception();

            base.Add(entity);
        }
        public override void Delete(TeacherEntity entity)
        {
            CheckIsTeacherDeletable(entity);

            base.Delete(entity);
        }
        public override void Update(TeacherEntity entity)
        {
            if(!IsTeacherValid(entity))
                throw new Exception();

            base.Update(entity);
        }

        public override Task DeleteAsync(int id) => base.DeleteAsync(id);
        public override Task<List<TeacherEntity>> GetAsync() => base.GetAsync();
        public override Task<TeacherEntity> GetAsync(int id) => base.GetAsync(id);
        public override Task<List<TeacherEntity>> GetAsync(Expression<Func<TeacherEntity, bool>> predicate)
            => base.GetAsync(predicate);


        private bool IsTeacherValid(TeacherEntity entity)
        {
            return !IsTeacherNameEmpty(entity.TeacherName, entity.TeacherLastName)
                && IsLetter(entity.TeacherName, entity.TeacherLastName)
                && IsBirthdayValid(entity.Birthday);
        }

        private bool IsLetter(string name, string lastname)
        {
            return name.Count(c => char.IsLetter(c)) == name.Length
                && lastname.Count(c => char.IsLetter(c)) == lastname.Length;
        }

        private bool IsTeacherNameEmpty(string name, string lastName) => string.IsNullOrEmpty(name)
            && string.IsNullOrEmpty(lastName);

        private bool IsBirthdayValid(DateTime birthday)
        {
            return birthday.Year < 1999 && birthday.Year > 1950;
        }

        private void CheckIsTeacherDeletable(TeacherEntity entity)
        {
            var isTeacherUsedAtTeacherCourses = dbContext.TeacherCourses
                .Include(tc => tc.Teacher)
                .Any(tc => tc.Teacher.Id == entity.Id);

            if (isTeacherUsedAtTeacherCourses)
                throw new Exception();
        }
    }
}
