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
    public class TeacherCourseController : ApiController
    {
        private readonly ITeacherCourseRepository _teacherCourseRepository;
     
        public TeacherCourseController() 
        { 
            _teacherCourseRepository = new TeacherCourseRepository();
        }

        [System.Web.Http.HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var teachers = await _teacherCourseRepository.GetAsync();

            return Ok(teachers);
        }
    }
}