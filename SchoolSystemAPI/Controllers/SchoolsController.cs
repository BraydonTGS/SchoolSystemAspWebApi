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
        [Route("GetAllSchools")]
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
        [Route("GetSchoolById/{Id}")]
        [HttpGet]
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
        // Create a New School //
        [Route("CreateNewSchool")]
        [HttpPost]
        [ProducesResponseType(200, Type =typeof(IEnumerable<School>))]
        [ProducesResponseType(400)]
        public IActionResult CreateNewSchool(string Name, string Address, string City, string State, string Zipcode )
        {

            var newSchool = _repository.CreateSchool(Name, Address, City, State, Zipcode);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return GetSchools();    
        }

        // Create a New School //
        [Route("CreateNewSchoolTest")]
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(IEnumerable<School>))]
        [ProducesResponseType(400)]
        public IActionResult CreateNewSchoolTest(School school)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.CreateSchoolTest(school);

            return GetSchools();
        }
    }
}
