using BusinessLogic.Repositories.Repositorey;
using BusinessLogic.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Repositories.Course
{
    public interface ICourseRepository : IRepository<DataAccess.Entities.Course>
    {
        IReadOnlyList<int> InsertedIds { get; }

        Task<List<CourseViewModel>> GetAsync();
        void Insert(string name);
        Task UpdateAsync(int id, string name);
        Task Delete(int id);
    }
}
