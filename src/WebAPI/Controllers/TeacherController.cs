using BusinessLogic.Repositories;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class TeacherController : ApiController
    {
        
        public TeacherController() {}

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var repository = new TeacherRepository();

            var teachers = await repository.GetAsync();

            return Ok(teachers);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post()
        {
            throw new NotImplementedException();
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