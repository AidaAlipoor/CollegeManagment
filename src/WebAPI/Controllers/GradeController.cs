using BusinessLogic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;


namespace WebAPI.Controllers
{
    public class GradeController : ApiController
    {
        private readonly IGradeRepository _repository;

        public GradeController() 
        { 
            _repository = new GradeRepository(); 
        }
       

        public async Task<IHttpActionResult> Get()
        {
            var Grade = await _repository.GetAsync();

            return Ok(Grade);
        }
    }
}