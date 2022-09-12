using BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TeacherEntity = DataAccess.Entities.Teacher;

namespace BusinessLogic.Repositories
{
    public class TeacherRepository : Repository<TeacherEntity>, ITeacherRepository
    {
        public override void Add(TeacherEntity entity)
        {
            ValidateTeacher(entity);

            base.Add(entity);
        }
        public override void Delete(TeacherEntity entity)
        {
            CheckIsTeacherDeletable(entity);

            base.Delete(entity);
        }
        public override void Update(TeacherEntity entity)
        {
            ValidateTeacher(entity);

            base.Update(entity);
        }

        public override Task DeleteAsync(int id) => base.DeleteAsync(id);

        public override Task<List<TeacherEntity>> FetchAsync() => base.FetchAsync();
        public override Task<TeacherEntity> FetchAsync(int id) => base.FetchAsync(id);
        public override Task<List<TeacherEntity>> FetchAsync(Expression<Func<TeacherEntity, bool>> predicate)
            => base.FetchAsync(predicate);

        public override Task SaveAsync()
        {
            

            return base.SaveAsync();
        }

        public async Task<List<TeacherViewModel>> GetAsync()
        {
            return await dbContext.Teachers
                .Select(t => new TeacherViewModel
                {
                    Id = t.Id,
                    Name = t.TeacherName,
                    Lastname = t.TeacherLastName,
                    Birthday = t.Birthday
                })
                .ToListAsync();
        }

        public int Insert(string name, string lastname, DateTime birthday)
        {
            var teacher = new TeacherEntity
            {
                TeacherName = name,
                TeacherLastName = lastname,
                Birthday = birthday,
            };

            Add(teacher);

            return teacher.Id;
        }


        private void ValidateTeacher(TeacherEntity entity)
        {
            if (IsTeacherNameEmpty(entity.TeacherName, entity.TeacherLastName)
                || !IsLetter(entity.TeacherName, entity.TeacherLastName))
                throw new Exception("Name and lastname are invalid");

            if (!IsBirthdayValid(entity.Birthday))
                throw new Exception($"Birthday is invalid. It should be between {TeacherEntity.MinLimitedYear} and {TeacherEntity.MaxLimitedYear}");
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
            return birthday.Year < TeacherEntity.MaxLimitedYear
                   && birthday.Year > TeacherEntity.MinLimitedYear;
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
