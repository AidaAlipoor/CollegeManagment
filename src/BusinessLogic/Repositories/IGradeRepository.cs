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
        void Insert(string name);
        Task UpdateAsync(int id, string name);
        Task Delete(int id);
    }
}

    

