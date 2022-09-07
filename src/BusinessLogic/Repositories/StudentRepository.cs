using DataAccess.EntitiesConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using StudentEntity = DataAccess.Entities.Student;

namespace BusinessLogic.Repositories
{
    public class StudentRepository : Repository<StudentEntity>
    {
        public StudentRepository(CollegeManagmentContext dbContext)
            : base(dbContext) { }

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
        public override Task<List<StudentEntity>> GetAsync()
        {
            return base.GetAsync();
        }
        public override Task<StudentEntity> GetAsync(int id)
        {
            return base.GetAsync(id);
        }
        public override Task<List<StudentEntity>> GetAsync(Expression<Func<StudentEntity, bool>> predicate)
        {
            return base.GetAsync(predicate);
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
