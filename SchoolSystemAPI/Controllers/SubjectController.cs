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
    }
}
