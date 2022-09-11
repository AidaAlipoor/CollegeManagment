using BusinessLogic.ViewModels;
using DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Repositories
{
    public interface ITeacherRepository : IRepository<Teacher>
    {    
        Task <List<TeacherViewModel>> GetAsync();

    }
}
