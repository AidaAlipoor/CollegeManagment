using BusinessLogic.ViewModels;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repositories
{
    public interface ITeacherCourseRepository : IRepository<TeacherCourse>
    {
        IReadOnlyList<int> InsertedIds { get; }

        Task<List<TeacherCourseViewModel>> GetAsync();
        Task Insert(int teacherId , int courseId);
        Task UpdateAsync(int id , int teacherId, int courseId);
        Task Delete(int id);
    }
}
