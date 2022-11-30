using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetSchools()
        {
            var schools = await _repository.GetAllSchoolsAsync();

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
            var exists = await _repository.SchoolExistsAsync(Id);
            if (!exists)
            {
                return NotFound(); 
            }
            var school = await _repository.GetSchoolByIdAsync(Id);

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
            var exists = await _repository.SchoolExistsAsync(Id);
            if (!exists)
            {
                return NotFound(); 
            }

            var school = await _repository.GetSchoolByIdAsync(Id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (school is null)
            {
                return BadRequest("School not Found"); 
            }

            var updateMake = await _repository.UpdateSchoolAsync(school, updateSchool); 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updateMakeDTO = new SchoolDTO()
            {   SchoolId = updateMake.SchoolId,
                SchoolName = updateMake.SchoolName,
                Address = updateMake.Address,
                City = updateMake.City,
                State = updateMake.State,
                PostalCode = updateMake.PostalCode,
            };
            
            return Ok(updateMakeDTO);
        }

        // Create a New School //
        [Route("CreateNewSchool")]
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(School))]
        [ProducesResponseType(400)]
        public async Task< IActionResult> CreateNewSchool(School school)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newSchool = await _repository.CreateSchoolAsync(school);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newSchoolDTO = new SchoolDTO()
            {
                SchoolId = newSchool.SchoolId,
                SchoolName = newSchool.SchoolName,
                Address = newSchool.Address,
                City = newSchool.City,
                State = newSchool.State,
                PostalCode = newSchool.PostalCode,
            }; 

            return Ok(newSchoolDTO);
        }

        // Delete School by Id //
        [Route("DeleteSchool/{Id}")]
        [HttpDelete]
        [ProducesResponseType(200, Type=typeof(IEnumerable<School>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteSchoolById(int Id)
        {

            var schoolToDelete = await _repository.GetSchoolByIdAsync(Id); 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (schoolToDelete == null) 
            {
                return BadRequest("School Not Found");
            }

            _repository.DeleteSchool(schoolToDelete);


            return await GetSchools();
        }

    }
}
