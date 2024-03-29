﻿using BusinessLogic.Repositories.Repositorey;
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

namespace BusinessLogic.Repositories.Student
{
    internal class StudentRepository : Repository<StudentEntity>, IStudentRepository
    {
        public StudentRepository(ICollegeManagmentContext dbcontext) : base(dbcontext) { }

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

        public override async Task DeleteAsync(int id) => await base.DeleteAsync(id);
        public override async Task<List<StudentEntity>> FetchAsync() => await base.FetchAsync();
        public override async Task<StudentEntity> FetchAsync(int id) => await base.FetchAsync(id);
        public override async Task<List<StudentEntity>> FetchAsync(Expression<Func<StudentEntity, bool>> predicate) => await  base.FetchAsync(predicate);


        public override async Task SaveAsync()
        {
            var addedEntities = _dbContext.ChangeTracker
               .Entries<StudentEntity>()
               .Where(t => t.State == EntityState.Added)
               .ToArray();

            await base.SaveAsync();

            InsertedIds = addedEntities.Select(t => t.Entity.Id).ToList();
        }
        public async Task<List<StudentViewModel>> GetAsync()
        {
            var student = await _dbContext.Set<StudentEntity>()
                .Select(s => new StudentViewModel
                {
                    Id = s.Id,
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
            CheckDoesIdExist(id);

            var student = await FetchAsync(id);

            student.StudentName = name;
            student.StudentLastName = lastname;
            student.IdNumber = idNumber;

            Update(student);
        }
        public async Task Delete(int id)
        {
            CheckDoesIdExist(id);

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
        private void CheckDoesIdExist(int id)
        {
            var doesIdExistInStudent = FetchAsync(id);
            if (doesIdExistInStudent == null)
                throw new Exception("this id does not exist");

        }

    }
}
