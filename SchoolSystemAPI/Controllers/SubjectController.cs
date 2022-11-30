using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystemAPI.DTO;
using SchoolSystemAPI.Interfaces;
using SchoolSystemAPI.Models;

namespace SchoolSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectRepository _repository;

        public SubjectController(ISubjectRepository repository)
        {
            _repository = repository;
        }

        // Get all Subjects //
        [Route("GetAllSubjects")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Subject>))]
        public async Task<IActionResult> GetStudents()
        {
            var subjects = await _repository.GetAllSubjectsAsync();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var subjectDTO = subjects.Select(x => new SubjectDTO(x.SubjectId, x.SubjectName, x.ClassRoom)); 


            return Ok(subjectDTO);
        }

        // Get Subject By Id //
        [Route("GetSubjectById/{Id}")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Subject))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetSubjectById(int Id)
        {
            var exists = await _repository.SubjectExistsAsync(Id);
            if (!exists)
            {
                return NotFound();
            }
            var subject = await _repository.GetSubjectByIdAsync(Id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(subject);
        }

        // Update an Existing Subject //
        [Route("UpdateSubject/{Id}")]
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(Subject))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateSubject(int Id, Subject updateSubject)
        {
            var exists = await _repository.SubjectExistsAsync(Id);
            if (!exists)
            {
                return NotFound();
            }

            var subject = await _repository.GetSubjectByIdAsync(Id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (subject is null)
            {
                return BadRequest("School not Found");
            }

            var update = await _repository.UpdateSubjectAsync(subject, updateSubject);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedSubject = new SubjectDTO()
            {
                SubjectId = Id,
                SubjectName = update.SubjectName,
                ClassRoom= update.ClassRoom,
            };

            return Ok(updatedSubject);
        }

        // Create a New Subject //
        [Route("CreateNewSubject")]
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Subject))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateNewSubject(Subject subject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newSubject = await _repository.CreateSubjectAsync(subject);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newSubjectDTO = new SubjectDTO()
            {
                SubjectId = newSubject.SubjectId,
                SubjectName = newSubject.SubjectName,
                ClassRoom= newSubject.ClassRoom
            };

            return Ok(newSubjectDTO);
        }

        // Delete Subject by Id //
        [Route("DeleteSubject/{Id}")]
        [HttpDelete]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Subject>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteSubjectById(int Id)
        {

            var subjectToDelete = await _repository.GetSubjectByIdAsync(Id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (subjectToDelete == null)
            {
                return BadRequest("School Not Found");
            }

            _repository.DeleteSubject(subjectToDelete);


            return await GetStudents();
        }
    }
}
