using IssueManagement.Business.Abstract;
using IssueManagement.Data;
using IssueManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace IssueManagement.Controllers
{
	[Authorize]
	public class ProjectController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly IProjectService _projectService;
		private readonly IIssueService _issueService;
		private readonly UserManager<IdentityUser> _userManager;

		public ProjectController(IProjectService projectService, ApplicationDbContext applicationDbContext, IIssueService issueService, UserManager<IdentityUser> userManager)
		{
			_projectService = projectService;
			_context = applicationDbContext;
			_issueService = issueService;
			_userManager = userManager;
		}

		[HttpGet]
		public async Task<IActionResult> MyProject()
		{
			var getProjectList = _projectService.GetAll();
			ViewBag.issueList = _issueService.GetAll();
			var user = await _userManager.GetUserAsync(HttpContext.User);
			ViewBag.user = user;
			return View(getProjectList);
		}

		public async Task<IActionResult> AllProjects()
		{
            var getProjectList = _projectService.GetAll();
            ViewBag.issueList = _issueService.GetAll();
            var user = await _userManager.GetUserAsync(HttpContext.User);
            ViewBag.user = user;
            return View(getProjectList);
        }

		[HttpGet]
		public async Task<IActionResult> Detail(int id)
		{
			var getProjectList = _projectService.GetAll();
			ViewBag.issueList = _issueService.GetAll();
			var user = await _userManager.GetUserAsync(HttpContext.User);
			ViewBag.user = user;
			var result = _projectService.Get(id);
			return View(result);
		}
		[HttpGet]
		public async Task<IActionResult> Update(int id)
		{
			var result = _projectService.Get(id);
			return View(result);
		}

		[HttpPost]
		public async Task<IActionResult> Update(ProjectModel projectModel)
		{
			_projectService.Update(projectModel);
			return RedirectToAction("MyProject");
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(int id)
		{
			_projectService.Remove(id);
			return View();
		}

		
	}
}
