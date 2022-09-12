using BusinessLogic.Repositories;
using System;
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
            var id = _repository.Insert(teacherDto.Name, teacherDto.Lastname, teacherDto.BirthDay);

            await _repository.SaveAsync();

            return Ok(id);
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put()
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete()
        {
            throw new NotImplementedException();
        }
    }
}