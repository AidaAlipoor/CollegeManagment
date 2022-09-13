using BusinessLogic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
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

        public async Task<IHttpActionResult> Get()
        {
            var student = await _repository.GetAsync();

            return Ok(student);
        }
        [System.Web.Http.HttpPost]
        public async Task<IHttpActionResult> Post(CourseDto courseDto)
        {
            _repository.Insert(courseDto.Name);

            await _repository.SaveAsync();

            var id = _repository.InsertedIds.Single();

            return Ok(id);
        }
        [System.Web.Http.HttpPut]
        public async Task<IHttpActionResult> Put(int id, CourseDto courseDto)
        {
            await _repository.UpdateAsync(id, courseDto.Name);

            await _repository.SaveAsync();

            return Ok();
        }

    }
}