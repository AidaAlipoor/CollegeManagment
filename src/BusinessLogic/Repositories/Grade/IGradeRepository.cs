using BusinessLogic.Repositories.Repositorey;
using BusinessLogic.ViewModels;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradeEntity = DataAccess.Entities.Grade;

namespace BusinessLogic.Repositories.Grade
{
    public interface IGradeRepository : IRepository<GradeEntity>
    {
        IReadOnlyList<int> InsertedIds { get; }

        Task<List<GradeViewModel>> GetAsync();
        Task Insert(int score , int teacherCourseId , int studentId);
        Task UpdateAsync(int id, int score, int teacherCourseId, int studentId);
        Task Delete(int id);
    }
}

    

