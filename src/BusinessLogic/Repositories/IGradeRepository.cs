using BusinessLogic.ViewModels;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repositories
{
    public interface IGradeRepository : IRepository<Grade>
    {
        IReadOnlyList<int> InsertedIds { get; }

        Task<List<GradeViewModel>> GetAsync();
        Task Insert(int score , int teacherCourseId , int studentId);
        Task UpdateAsync(int id, int score, int teacherCourseId, int studentId);
        Task Delete(int id);
    }
}

    

