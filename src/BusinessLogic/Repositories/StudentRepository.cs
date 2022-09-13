using BusinessLogic.ViewModels;
using DataAccess.EntitiesConfiguration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using StudentEntity = DataAccess.Entities.Student;

namespace BusinessLogic.Repositories
{
    public class StudentRepository : Repository<StudentEntity>, IStudentRepository
    {
        public IReadOnlyList<int> InsertedIds { get ; private set; }

        public override void Add(StudentEntity entity)
        {
            if (!IsStudentValid(entity))
                throw new Exception();

            base.Add(entity);
        }
        public override void Delete(StudentEntity entity)
        {
            base.Delete(entity);
        }
        public override void Update(StudentEntity entity)
        {
            base.Update(entity);
        }

        public override Task DeleteAsync(int id)
        {
            return base.DeleteAsync(id);
        }
        public override Task<List<StudentEntity>> FetchAsync()
        {
            return base.FetchAsync();
        }
        public override Task<StudentEntity> FetchAsync(int id)
        {
            return base.FetchAsync(id);
        }
        public override Task<List<StudentEntity>> FetchAsync(Expression<Func<StudentEntity, bool>> predicate)
        {
            return base.FetchAsync(predicate);
        }


        public override async Task SaveAsync()
        {
            var addedEntities = dbContext.ChangeTracker
               .Entries<StudentEntity>()
               .Where(t => t.State == EntityState.Added)
               .ToArray();

            await base.SaveAsync();

            InsertedIds = addedEntities.Select(t => t.Entity.Id).ToList();
        }
        public async Task<List<StudentViewModel>> GetAsync()
        {
            var student = await dbContext.Students
                .Select(s => new StudentViewModel
                {
                    Name = s.StudentName,
                    LastName = s.StudentLastName,
                    IdNumber = s.IdNumber
                })
                .ToListAsync();

            return student;
        }
        public void Insert(string name, string lastname, int idNumber)
        {
            var student = new StudentEntity
            {
                StudentName = name
                ,
                StudentLastName = lastname
                ,
                IdNumber = idNumber
            };

            Add(student);
        }
        public Task UpdateAsync(int id, string name, string lastname, int idNumber)
        {
            throw new NotImplementedException();
        }
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }



        private bool IsStudentValid(StudentEntity entity)
        {
            return !IsStudentNameEmpty(entity.StudentName, entity.StudentLastName)
                && IsLetter(entity.StudentName, entity.StudentLastName)
                && IsIdNumberValid(entity.IdNumber);
        }
        private bool IsStudentNameEmpty(string name, string lastName) => string.IsNullOrEmpty(name)
            && string.IsNullOrEmpty(lastName);
        private bool IsLetter(string name, string lastName)
        {
            return name.Count(c => char.IsLetter(c)) == name.Length
                && lastName.Count(c => char.IsLetter(c)) == lastName.Length;
        }
        private bool IsIdNumberValid(int idNumber)
        {
            return idNumber.ToString().Length == StudentEntity.IdNumberLengthLimit;
        }


    }
}
