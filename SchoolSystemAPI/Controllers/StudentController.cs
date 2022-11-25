using Microsoft.AspNetCore.Mvc;

namespace SchoolSystemAPI.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
