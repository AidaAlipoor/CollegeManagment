using BusinessLogic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

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

    }
}