using BusinessLogic.Repositories;
using BusinessLogic.Repositories.Student;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPI.DTOs;


namespace WebAPI.Controllers
{
    public class StudentController : ApiController
    {
        private readonly IStudentRepository _repository;
        public StudentController(IStudentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
           var student = await _repository.GetAsync();

            return Ok(student);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(StudentDto studentDto)
        {
            _repository.Insert(studentDto.Name, studentDto.Lastname, studentDto.IdNumber);

            await _repository.SaveAsync();

            var id = _repository.InsertedIds.Single();

            return Ok(id);
        }
        [HttpPut]
        public async Task<IHttpActionResult> Put(int id, StudentDto studentDto)
        {
            await _repository.UpdateAsync(id, studentDto.Name, studentDto.Lastname, studentDto.IdNumber);

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