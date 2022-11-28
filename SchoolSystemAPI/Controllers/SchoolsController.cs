using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using SchoolSystemAPI.DTO;
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
        public async Task<IActionResult> GetSchoolsAsync()
        {
            var schools = await _repository.GetAllSchools();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var schoolDTO = schools.Select(x => new SchoolDTO(x.SchoolId, x.SchoolName, x.Address, x.City, x.State, x.PostalCode)).ToList();

     
            return Ok(schoolDTO); 
        }

        // Get School By Id //
        [Route("GetSchoolById/{Id}")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(School))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetSchoolById(int Id)
        {
            if (!_repository.SchoolExists(Id))
            {
                return NotFound(); 
            }
            var school = await _repository.GetSchoolById(Id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            return Ok(school);
        }

        // Update an Existing School //
        [Route("UpdateSchool/{Id}")]
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(School))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateSchool(int Id, School updateSchool) 
        {
            if (!_repository.SchoolExists(Id))
            {
                return NotFound(); 
            }

            var school = await _repository.GetSchoolById(Id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (school is null)
            {
                return BadRequest("School not Found"); 
            }
            var updateMake = await _repository.UpdateSchool(school, updateSchool); 
            
            return Ok(updateMake);
        }

        // Create a New School //
        [Route("CreateNewSchoolTest")]
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(School))]
        [ProducesResponseType(400)]
        public IActionResult CreateNewSchool(School school)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           var newSchool = _repository.CreateSchool(school);

            return Ok(newSchool);
        }

        // Delete School by Id //
        [Route("DeleteSchool/{Id}")]
        [HttpDelete]
        [ProducesResponseType(200, Type=typeof(IEnumerable<School>))]
        [ProducesResponseType(400)]
        public IActionResult DeleteSchoolById(int Id)
        {

            var SchoolToDelete = _repository.GetSchoolById(Id); 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (SchoolToDelete == null) 
            {
                return BadRequest("School Not Found");
            }

            _repository.DeleteSchool(SchoolToDelete); 


            return (IActionResult)GetSchoolsAsync(); 
        }

    }
}
