using BusinessLogic.Repositories;
using BusinessLogic.Repositories.Teacher;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPI.DTOs;

namespace WebAPI.Controllers
{
    public class TeacherController : ApiController
    {
        private readonly ITeacherRepository _repository;
        public TeacherController() { _repository = new TeacherRepository(); }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var teachers = await _repository.GetAsync();

            return Ok(teachers);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(TeacherDto teacherDto)
        {
            _repository.Insert(teacherDto.Name, teacherDto.Lastname, teacherDto.BirthDay);

            await _repository.SaveAsync();

            var id = _repository.InsertedIds.Single();

            return Ok(id);
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(int id, TeacherDto teacherDto)
        {
            await _repository.UpdateAsync(id, teacherDto.Name, teacherDto.Lastname, teacherDto.BirthDay);

            await _repository.SaveAsync();

            return Ok();
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            await _repository.Delete(id);

            await _repository.SaveAsync(); 
            
            return Ok();
        }
    }
}