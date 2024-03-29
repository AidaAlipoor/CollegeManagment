﻿
using BusinessLogic.Repositories.Repositorey;
using BusinessLogic.ViewModels;
using DataAccess.EntitiesConfiguration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CourseEntity = DataAccess.Entities.Course;

namespace BusinessLogic.Repositories.Course
{
    internal class CourseRepository : Repository<CourseEntity> , ICourseRepository
    {
        public CourseRepository(ICollegeManagmentContext dbcontext) : base(dbcontext) { }

        public IReadOnlyList<int> InsertedIds { get; private set; }

        public override void Add(CourseEntity entity)
        {
            ValidCourse(entity);

            base.Add(entity);
        }
        public override void Delete(CourseEntity entity)
        {
            CheckIsCourseDeletable(entity);
            base.Delete(entity);
        }
        public override void Update(CourseEntity entity)
        {
            ValidCourse(entity);
            base.Update(entity);
        }

        public override async Task DeleteAsync(int id) => await base.DeleteAsync(id);
        public override async Task<List<CourseEntity>> FetchAsync() => await base.FetchAsync();
        public override async Task<CourseEntity> FetchAsync(int id) => await base.FetchAsync(id);
        public override async Task<List<CourseEntity>> FetchAsync(Expression<Func<CourseEntity, bool>> predicate) => await base.FetchAsync(predicate);


        public override async Task SaveAsync()
        {
            var addedEntities = _dbContext.ChangeTracker
                .Entries<CourseEntity>()
                .Where(t => t.State == EntityState.Added)
                .ToArray();

            await base.SaveAsync();

            InsertedIds = addedEntities.Select(t => t.Entity.Id).ToList();
        }
        public async Task<List<CourseViewModel>> GetAsync()
        {
            return await _dbContext.Set<CourseEntity>()
                .Select(c => new CourseViewModel 
                {
                    Id = c.Id,
                    Name = c.CourseName 
                })
                .ToListAsync();

        }
        public void Insert(string name)
        {
            var course = new CourseEntity{ CourseName = name};
            Add(course);
        }
        public async Task UpdateAsync(int id, string name)
        {
            CheckDoesIdExist(id);

           var course = await FetchAsync(id);

            course.CourseName = name;

            Update(course);
        }
        public async Task Delete(int id)
        {
            CheckDoesIdExist(id);

            var courseEntity = await FetchAsync(id);

            Delete(courseEntity);
        }


        private void ValidCourse(CourseEntity entity)
        {
            if (IsCourseNameEmpty(entity.CourseName) || IsLetter(entity.CourseName))
                throw new Exception("Name is invalid");
        } 
        private bool IsCourseNameEmpty(string name) => string.IsNullOrEmpty(name);
        private bool IsLetter(string name) => int.TryParse(name , out _);
        private void CheckIsCourseDeletable(CourseEntity entity)
        {
            bool isCourseUsedAtTeacherCourses = _dbContext.Set<DataAccess.Entities.TeacherCourse>()
                .Include(tc => tc.Course)
                .Any(tc => tc.Course.Id == entity.Id);

            if (isCourseUsedAtTeacherCourses)
                throw new Exception("this item can not be deleted!");
        }
        private async void CheckDoesIdExist(int id)
        {
            var doesIdExistInCourse = await FetchAsync(id);

            if (doesIdExistInCourse == null)
                throw new Exception("this id does not exist");

        }

    }
}
