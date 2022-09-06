using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class TeacherController : ApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            return  Ok(new[] { "Test", "Test test", "Chi miiiigiiiii test?" });
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