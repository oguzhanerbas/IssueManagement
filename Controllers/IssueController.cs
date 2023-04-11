using Microsoft.AspNetCore.Mvc;

namespace IssueManagement.Controllers
{
    public class IssueController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
