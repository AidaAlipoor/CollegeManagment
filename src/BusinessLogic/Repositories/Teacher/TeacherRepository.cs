using BusinessLogic.Repositories.Repositorey;
using BusinessLogic.ViewModels;
using DataAccess.EntitiesConfiguration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TeacherEntity = DataAccess.Entities.Teacher;

namespace BusinessLogic.Repositories.Teacher
{
    internal class TeacherRepository : Repository<TeacherEntity>, ITeacherRepository
    {
        public TeacherRepository(ICollegeManagmentContext dbcontext) : base(dbcontext) { }


        public IReadOnlyList<int> InsertedIds { get; private set; }

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


        public override async Task SaveAsync()
        {
            var addedEntities = _dbContext.ChangeTracker
                .Entries<TeacherEntity>()
                .Where(t => t.State == EntityState.Added)
                .ToArray();

            await base.SaveAsync();

            InsertedIds = addedEntities.Select(t => t.Entity.Id).ToList();
        }
        public async Task<List<TeacherViewModel>> GetAsync()
        {
            return await _dbContext.Set<TeacherEntity>()
                .Select(t => new TeacherViewModel
                {
                    Id = t.Id,
                    Name = t.TeacherName,
                    Lastname = t.TeacherLastName,
                    Birthday = t.Birthday
                })
                .ToListAsync();
        }
        public void Insert(string name, string lastname, DateTime birthday)
        {
            var teacher = new TeacherEntity
            {
                TeacherName = name,
                TeacherLastName = lastname,
                Birthday = birthday,
            };

            Add(teacher);
        }
        public async Task UpdateAsync(int id, string name, string lastname, DateTime birthday)
        {
           await CheckDoesIdExist(id);

            var teacher = await FetchAsync(id);

            teacher.TeacherName = name;
            teacher.TeacherLastName = lastname;
            teacher.Birthday = birthday;

            Update(teacher);
        }
        public async Task Delete(int id)
        {
            await CheckDoesIdExist(id);

            var teacherEntity = await FetchAsync(id);

            Delete(teacherEntity);
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
            var isTeacherUsedAtTeacherCourses = _dbContext.Set<DataAccess.Entities.TeacherCourse>()
                .Include(tc => tc.Teacher)
                .Any(tc => tc.Teacher.Id == entity.Id);

            if (isTeacherUsedAtTeacherCourses)
                throw new Exception("This item can not be deleted! ");
        }
        private async Task CheckDoesIdExist(int id)
        {
            var doesIdExistInTeacher = await FetchAsync(id);

            if (doesIdExistInTeacher == null)
                throw new Exception("this id does not exist");

        }

    }
}
