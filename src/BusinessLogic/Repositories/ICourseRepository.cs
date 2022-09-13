using BusinessLogic.ViewModels;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Repositories
{
    public interface ICourseRepository : IRepository<Course>
    {
        IReadOnlyList<int> InsertedIds { get; }

        Task<List<CourseViewModel>> GetAsync();
        void Insert(string name);
        Task UpdateAsync(int id, string name);
        Task Delete(int id);
    }
}
