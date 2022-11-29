using Microsoft.AspNetCore.Mvc;
using SchoolSystemAPI.Interfaces;

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
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
