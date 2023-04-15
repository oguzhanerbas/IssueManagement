using IssueManagement.Business.Abstract;
using IssueManagement.Data;
using IssueManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IssueManagement.Controllers
{
	[Authorize]
	public class ProjectController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly IProjectService _projectService;
		private readonly IIssueService _issueService;
		private readonly UserManager<IdentityUser> _userManager;



        public ProjectController(IProjectService projectService, ApplicationDbContext applicationDbContext,
			IIssueService issueService, UserManager<IdentityUser> userManager)
		{
			_projectService = projectService;
			_context = applicationDbContext;
			_issueService = issueService;
			_userManager = userManager;
		}

		[HttpGet]
		public async Task<IActionResult> AddProject()
		{
			// TODO: usersları çekmek için bunu kullanıyoruz.
            ViewBag.users = await _userManager.Users.ToListAsync(); 
            ViewBag.user = await _userManager.GetUserAsync(HttpContext.User);
			ViewBag.isValid = false;
            return View();
		}

        //[HttpPost]

        //      public async Task<IActionResult> AddProject(ProjectModel projectModel)
        //{
        //          if (ModelState.IsValid)
        //          {
        //              _projectService.Add(projectModel);
        //          }
        //          else
        //              ViewBag.HataVarMi = true;

        //          return RedirectToAction("MyProject");
        //      }

        [HttpPost]
        public async Task<IActionResult> AddProject(ProjectModel projectModel)
        {
            if (ModelState.IsValid)
            {
                _projectService.Add(projectModel);
                return RedirectToAction("MyProject");
			}
			else
			{
                ViewBag.users = await _userManager.Users.ToListAsync();
                ViewBag.user = await _userManager.GetUserAsync(HttpContext.User);
                ViewBag.isValid = true;
			}
            
            return View();
        }

        [HttpGet]
		public async Task<IActionResult> Detail(int id)
		{
			ViewBag.issueList = _issueService.GetAll();
			var result = _projectService.Get(id);
			return View(result);
		}
		[HttpGet]
		public async Task<IActionResult> Update(int id)
		{
            ViewBag.users = await _userManager.Users.ToListAsync();
            ViewBag.user = await _userManager.GetUserAsync(HttpContext.User);
            var result = _projectService.Get(id);
			return View(result);
		}

		//[HttpPost]
		//public async Task<IActionResult> Update(ProjectModel projectModel)
		//{
		//	_projectService.Update(projectModel);
		//	return RedirectToAction("MyProject");
		//}

		[HttpPost]
		public async Task<IActionResult> Update(ProjectModel projectModel)
		{
            if (ModelState.IsValid)
            {
                _projectService.Update(projectModel);
                return RedirectToAction("MyProject");
            }
            else
            {
                ViewBag.users = await _userManager.Users.ToListAsync();
                ViewBag.user = await _userManager.GetUserAsync(HttpContext.User);
                var result = _projectService.Get(projectModel.Id);
                return View(result);
            }
			
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			var issues = _issueService.GetAll().Where(p=>p.Id == id);
			foreach (var issue in issues)
			{
				_issueService.Remove(issue.Id);
			}
			_projectService.Remove(id);
			// Get the URL of the previous page
			string previousUrl = Request.Headers["Referer"].ToString();
			// Redirect the user to the previous page
			return Redirect(previousUrl);
		}

        [HttpGet]
        public async Task<IActionResult> MyProject()
        {
            var getProjectList = _projectService.GetAll();
            ViewBag.issueList = _issueService.GetAll();
            var user = await _userManager.GetUserAsync(HttpContext.User);
            ViewBag.user = user;
			getProjectList = getProjectList.Where(p=>p.Author == user.UserName).ToList();
            return View(getProjectList);
        }

        [HttpGet]
        public async Task<IActionResult> AllProjects()
        {
            var getProjectList = _projectService.GetAll();
            ViewBag.issueList = _issueService.GetAll();
            return View(getProjectList);
        }

    }
}
