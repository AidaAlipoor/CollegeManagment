using BusinessLogic.ViewModels;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Repositories
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
        IReadOnlyList<int> InsertedIds { get; }

        Task<List<TeacherViewModel>> GetAsync();
        void Insert(string name, string lastname, DateTime birthday);
        Task UpdateAsync(int id, string name, string lastname, DateTime birthday);
        Task Delete(int id);
    }
}
