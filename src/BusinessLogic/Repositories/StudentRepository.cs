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
            ValidStudent(entity);

            base.Add(entity);
        }
        public override void Delete(StudentEntity entity)
        {
            base.Delete(entity);
        }
        public override void Update(StudentEntity entity)
        {
            ValidStudent(entity);

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
        public async Task UpdateAsync(int id, string name, string lastname, int idNumber)
        {
            var student = await FetchAsync(id);

            student.StudentName = name;
            student.StudentLastName = lastname;
            student.IdNumber = idNumber;

            Update(student);
        }
        public async Task Delete(int id)
        {
            CheckIsIdExist(id);

            var student = await FetchAsync(id);
            Delete(student);
        }



        private void ValidStudent(StudentEntity entity)
        {
           if(IsStudentNameEmpty(entity.StudentName, entity.StudentLastName) || !IsLetter(entity.StudentName, entity.StudentLastName))
                throw new Exception("Name and lastname are invalid");

            if (!IsIdNumberValid(entity.IdNumber))
                throw new Exception($"Id Number is invalid. it could not be more or less than {StudentEntity.IdNumberLengthLimit} numbers");

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

        private void CheckIsIdExist(int id)
        {
            var isIdExistInTeacher = dbContext.Students.Any(t => t.Id == id);
            if (!isIdExistInTeacher)
                throw new Exception("this id does not exist");

        }

    }
}
