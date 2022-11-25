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

        // Get School By Id //
        [HttpGet("{Id}")]
        [ProducesResponseType(200, Type = typeof(School))]
        [ProducesResponseType(400)]
        public IActionResult GetSchoolById(int Id)
        {
            if (!_repository.SchoolExists(Id))
            {
                return NotFound(); 
            }
            var school = _repository.GetSchoolById(Id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            return Ok(school);

        }
    }
}
