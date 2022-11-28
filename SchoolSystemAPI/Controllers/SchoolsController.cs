﻿using Microsoft.AspNetCore.Mvc;
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

        // Update an Existing School //
        [Route("UpdateSchool/{Id}")]
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(School))]
        [ProducesResponseType(400)]
        public IActionResult UpdateSchool(int Id, School newSchool) 
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
            if (school is null)
            {
                return BadRequest("School not Found"); 
            }
            var updateMake = _repository.UpdateSchool(school, newSchool); 
            
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
        [HttpPost]
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


            return GetSchools(); 
        }

    }
}
