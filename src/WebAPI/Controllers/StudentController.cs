using BusinessLogic.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using WebAPI.DTOs;


namespace WebAPI.Controllers
{
    public class StudentController : ApiController
    {
        private readonly IStudentRepository _repository;
        public StudentController() => _repository = new StudentRepository();

        [System.Web.Http.HttpGet]
        public async Task<IHttpActionResult> Get()
        {
           var student = await _repository.GetAsync();

            return Ok(student);
        }
        [System.Web.Http.HttpPost]
        public async Task<IHttpActionResult> Post(StudentDto studentDto)
        {
            _repository.Insert(studentDto.Name, studentDto.Lastname, studentDto.IdNumber);

            await _repository.SaveAsync();

            var id = _repository.InsertedIds.Single();

            return Ok(id);
        }

        public async Task<IHttpActionResult> Put(int id, StudentDto studentDto)
        {
            await _repository.UpdateAsync(id, studentDto.Name, studentDto.Lastname, studentDto.IdNumber);

            await _repository.SaveAsync();

            return Ok();
        }
    }
}