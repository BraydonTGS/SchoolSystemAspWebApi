using Microsoft.AspNetCore.Mvc;
using SchoolSystemAPI.DTO;
using SchoolSystemAPI.Interfaces;
using SchoolSystemAPI.Models;

namespace SchoolSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
       
        private readonly IStudentRepository _repository;

        public StudentController(IStudentRepository repository)
        {
            _repository = repository;
        }
        // Get all Students //
        [Route("GetAllStudents")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Student>))]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _repository.GetAllStudentsAsync();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var studentDTO = students.Select(x => new StudentDTO(x.StudentId, x.FirstName, x.LastName, x.Email, x.ContactNumber)).ToList();


            return Ok(studentDTO);
        }

        // Get Student By Id //
        [Route("GetStudentById/{Id}")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Student))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetStudentById(int Id)
        {
            var exists = await _repository.StudentExistsAsync(Id);
            if (!exists)
            {
                return NotFound();
            }
            var student = await _repository.GetStudentByIdAsync(Id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(student);
        }

        // Update an Existing Student //
        [Route("UpdateStudent/{Id}")]
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(Student))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateStudent(int Id, Student updateStudent)
        {
            var exists = await _repository.StudentExistsAsync(Id);
            if (!exists)
            {
                return NotFound();
            }

            var student = await _repository.GetStudentByIdAsync(Id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (student is null)
            {
                return BadRequest("School not Found");
            }

            var update = await _repository.UpdateStudentAsync(student, updateStudent);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updateStudentDTO = new StudentDTO()
            {
                StudentId= Id,
                FirstName= update.FirstName,
                LastName = update.LastName,
                ContactNumber= update.ContactNumber,
                Email = update.Email
            };

            return Ok(updateStudentDTO);
        }

        // Create a New Student //
        [Route("CreateNewStudent")]
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Student))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateNewStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newStudent = await _repository.CreateStudentAsync(student);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newStudentlDTO = new StudentDTO()
            {
               StudentId= newStudent.StudentId,
               FirstName= newStudent.FirstName,
               LastName= newStudent.LastName,
               ContactNumber= newStudent.ContactNumber,
               Email= newStudent.Email
            };

            return Ok(newStudentlDTO);
        }

        // Delete Student by Id //
        [Route("DeleteStudent/{Id}")]
        [HttpDelete]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Student>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteStudentById(int Id)
        {

            var StudentToDelete = await _repository.GetStudentByIdAsync(Id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (StudentToDelete == null)
            {
                return BadRequest("School Not Found");
            }

            _repository.DeleteStudent(StudentToDelete);


            return await GetStudents();
        }

    }
}

