using BusinessLogic.Repositories.Repositorey;
using BusinessLogic.ViewModels;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentEntity = DataAccess.Entities.Student;

namespace BusinessLogic.Repositories.Student
{
    public interface IStudentRepository : IRepository<StudentEntity>
    {
        IReadOnlyList<int> InsertedIds { get;}

        Task<List<StudentViewModel>> GetAsync();
        void Insert(string name, string lastname, int idNumber);
        Task UpdateAsync(int id, string name, string lastname, int idNumber);
        Task Delete(int id);
    }
}
