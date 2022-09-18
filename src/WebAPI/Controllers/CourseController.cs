using BusinessLogic.Repositories;
using BusinessLogic.Repositories.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebAPI.DTOs;

namespace WebAPI.Controllers
{
    public class CourseController : ApiController
    {
        private readonly ICourseRepository _repository;
        public CourseController()
        {
            _repository = new CourseRepository();
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var student = await _repository.GetAsync();

            return Ok(student);
        }
        [HttpPost]
        public async Task<IHttpActionResult> Post(CourseDto courseDto)
        {
            _repository.Insert(courseDto.Name);

            await _repository.SaveAsync();

            var id = _repository.InsertedIds.Single();

            return Ok(id);
        }
        [HttpPut]
        public async Task<IHttpActionResult> Put(int id, CourseDto courseDto)
        {
            await _repository.UpdateAsync(id, courseDto.Name);

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