using BusinessLogic.Repositories.Repositorey;
using BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeacherEntity = DataAccess.Entities.Teacher;

namespace BusinessLogic.Repositories.Teacher
{
    public interface ITeacherRepository : IRepository<TeacherEntity>
    {
        IReadOnlyList<int> InsertedIds { get; }

        Task<List<TeacherViewModel>> GetAsync();
        void Insert(string name, string lastname, DateTime birthday);
        Task UpdateAsync(int id, string name, string lastname, DateTime birthday);
        Task Delete(int id);
    }
}
