using Microsoft.AspNetCore.Mvc;

namespace SchoolSystemAPI.Controllers
{
    public class SchoolController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
