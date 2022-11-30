using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystemAPI.DTO;
using SchoolSystemAPI.Interfaces;
using SchoolSystemAPI.Models;

namespace SchoolSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _repository;

        public TeacherController(ITeacherRepository repository)
        {
            _repository = repository;
        }

        // Get all Teachers //
        [Route("GetAllTeachers")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Teacher>))]
        public async Task<IActionResult> GetTeachers()
        {
            var teachers = await _repository.GetAllTeachersAsync();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var teacherDTO = teachers.Select(x => new TeacherDTO(x.TeacherId, x.FirstName, x.LastName, x.ContactNumber, x.Email)); 


            return Ok(teacherDTO);
        }

        // Get Teacher By Id //
        [Route("GetTeacherById/{Id}")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Teacher))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetTeacherById(int Id)
        {
            var exists = await _repository.TeacherExistsAsync(Id);
            if (!exists)
            {
                return NotFound();
            }
            var teacher = await _repository.GetTeacherByIdAsync(Id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(teacher);
        }

        // Update an Existing Teacher //
        [Route("UpdateTeacher/{Id}")]
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(Teacher))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateTeacher(int Id, Teacher updateTeacher)
        {
            var exists = await _repository.TeacherExistsAsync(Id);
            if (!exists)
            {
                return NotFound();
            }

            var teacher = await _repository.GetTeacherByIdAsync(Id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (teacher is null)
            {
                return BadRequest("School not Found");
            }

            var update = await _repository.UpdateTeacherAsync(teacher, updateTeacher);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updateTeacherDTO = new TeacherDTO()
            {
                TeacherId = Id,
                FirstName = update.FirstName,
                LastName = update.LastName,
                ContactNumber = update.ContactNumber,
                Email = update.Email
            };

            return Ok(updateTeacherDTO);
        }

        // Create a New Student //
        [Route("CreateNewTeacher")]
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Teacher))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateNewTeacher(Teacher teacher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newTeacher = await _repository.CreateTeacherAsync(teacher);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newTeacherlDTO = new TeacherDTO()
            {
                TeacherId = newTeacher.TeacherId,
                FirstName = newTeacher.FirstName,
                LastName = newTeacher.LastName,
                ContactNumber = newTeacher.ContactNumber,
                Email = newTeacher.Email
            };

            return Ok(newTeacherlDTO);
        }

        // Delete Teacher by Id //
        [Route("DeleteTeacher/{Id}")]
        [HttpDelete]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Teacher>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteTeacherById(int Id)
        {

            var teacherToDelete = await _repository.GetTeacherByIdAsync(Id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (teacherToDelete == null)
            {
                return BadRequest("School Not Found");
            }

            _repository.DeleteTeacher(teacherToDelete);


            return await GetTeachers();
        }
    }
}
