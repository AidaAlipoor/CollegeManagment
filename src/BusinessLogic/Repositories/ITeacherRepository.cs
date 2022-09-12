using BusinessLogic.ViewModels;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Repositories
{
    public interface ITeacherRepository : IRepository<Teacher>
    {    
        Task <List<TeacherViewModel>> GetAsync();

        int Insert(string name, string lastname, DateTime birthday);
    }
}
