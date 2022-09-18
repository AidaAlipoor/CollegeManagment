using BusinessLogic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebAPI.DTOs;

namespace WebAPI.Controllers
{
    public class GradeController : ApiController
    {
        private readonly IGradeRepository _repository;

        public GradeController() 
        { 
            _repository = new GradeRepository(); 
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var Grade = await _repository.GetAsync();

            return Ok(Grade);
        }
        [HttpPost]
        public async Task<IHttpActionResult> Post(GradeDto gradeDto)
        {
            await _repository.Insert(gradeDto.Score ,gradeDto.TeacherCourseId , gradeDto.StudentId);

            await _repository.SaveAsync();

            var id = _repository.InsertedIds.Single();

            return Ok(id);
        }
        [HttpPut]
        public async Task<IHttpActionResult> Put(int id, GradeDto gradeDto)
        {
            await _repository.UpdateAsync(id ,gradeDto.Score , gradeDto.TeacherCourseId , gradeDto.StudentId);

            await _repository.SaveAsync();

            return Ok();
        }

    }
}