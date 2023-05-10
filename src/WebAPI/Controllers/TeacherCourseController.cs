using BusinessLogic.Repositories.TeacherCourse;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPI.DTOs;

namespace WebAPI.Controllers
{
    public class TeacherCourseController : ApiController
    {
        private readonly ITeacherCourseRepository _teacherCourseRepository;
     
        public TeacherCourseController(ITeacherCourseRepository repository) 
        { 
            _teacherCourseRepository = repository;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var teachers = await _teacherCourseRepository.GetAsync();

            return Ok(teachers);
        }
        [HttpPost]
        public async Task<IHttpActionResult> Post(TeacherCourseDto teacherCourseDto )
        {
            await _teacherCourseRepository.Insert(teacherCourseDto.TeacherId , teacherCourseDto.CourseId);

            await _teacherCourseRepository.SaveAsync();

            var id = _teacherCourseRepository.InsertedIds.Single();

            return Ok(id);
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(int id, TeacherCourseDto teacherCourseDto)
        {
            await _teacherCourseRepository.UpdateAsync(id, teacherCourseDto.TeacherId , teacherCourseDto.CourseId);

            await _teacherCourseRepository.SaveAsync();

            return Ok();
        }
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            await _teacherCourseRepository.DeleteAsync(id);

            await _teacherCourseRepository.SaveAsync();

            return Ok();
        }
    }
}