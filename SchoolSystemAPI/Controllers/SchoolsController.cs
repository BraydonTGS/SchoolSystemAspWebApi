using Microsoft.AspNetCore.Mvc;
using SchoolSystemAPI.Interfaces;
using SchoolSystemAPI.Models;

namespace SchoolSystemAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        private readonly ISchoolRepository _repository;

        public SchoolsController(ISchoolRepository repository)
        {
            _repository = repository;
        }

        // Get all Schools //
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<School>))]
        public IActionResult GetSchools()
        {
            var schools = _repository.GetAllSchools();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(schools); 
        }
    }
}
