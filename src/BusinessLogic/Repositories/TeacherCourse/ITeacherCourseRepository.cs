using BusinessLogic.Repositories.Repositorey;
using BusinessLogic.ViewModels;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherCourseEntity = DataAccess.Entities.TeacherCourse;

namespace BusinessLogic.Repositories.TeacherCourse
{
    public interface ITeacherCourseRepository : IRepository<TeacherCourseEntity>
    {
        IReadOnlyList<int> InsertedIds { get; }

        Task<List<TeacherCourseViewModel>> GetAsync();
        Task Insert(int teacherId , int courseId);
        Task UpdateAsync(int id , int teacherId, int courseId);
    }
}
