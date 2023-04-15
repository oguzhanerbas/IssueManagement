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
    public class IssueController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IProjectService _projectService;
        private readonly IIssueService _issueService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ICommentService _commentService;

        public IssueController(IProjectService projectService, ApplicationDbContext applicationDbContext,
            IIssueService issueService, UserManager<IdentityUser> userManager,
            ICommentService commentService)
        {
            _projectService = projectService;
            _context = applicationDbContext;
            _issueService = issueService;
            _userManager = userManager;
            _commentService = commentService;
        }

        [HttpGet]
        public async Task<IActionResult> MyIssues()
        {
            var issue = _issueService.GetAll();
            var user = await _userManager.GetUserAsync(HttpContext.User);
            ViewBag.user = user;
            ViewBag.projects = _projectService.GetAll();
            issue = issue.Where(p=>p.Author == user.UserName).ToList();
            return View(issue);
        }

        [HttpGet]
        public async Task<IActionResult> AllIssues()
        {
			var issue = _issueService.GetAll();
			ViewBag.projects = _projectService.GetAll();
			return View(issue);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
			ViewBag.user = await _userManager.GetUserAsync(HttpContext.User);
			var issue = _issueService.Get(id);
            ViewBag.issue = issue;
            ViewBag.comments = _commentService.GetAll().Where(p=>p.IssueModelId == id).ToList();
			ViewBag.project = _projectService.Get(issue.ProjectModelId);
			return View();
        }

        [HttpPost]
        public async Task<IActionResult> Detail(CommentModel commentModel)
        {
            if (ModelState.IsValid)
            {
				_commentService.Add(commentModel);
				string previousUrl = Request.Headers["Referer"].ToString();
				// Redirect the user to the previous page
				return Redirect("/Issue/Detail/" + commentModel.IssueModelId);
			}
            else
            {
				ViewBag.user = await _userManager.GetUserAsync(HttpContext.User);
				var issue = _issueService.Get(commentModel.IssueModelId);
				ViewBag.issue = issue;
				ViewBag.comments = _commentService.GetAll().Where(p => p.IssueModelId == commentModel.IssueModelId).ToList();
				ViewBag.project = _projectService.Get(issue.ProjectModelId);
				return View();
			}

		}

        [HttpGet]
        public async Task<IActionResult> Add()
        {

            ViewBag.users = await _userManager.Users.ToListAsync();
            ViewBag.user = await _userManager.GetUserAsync(HttpContext.User);
            ViewBag.projects = _projectService.GetAll();
			return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(IssueModel issue) 
        {
            if (ModelState.IsValid)
            {
                _issueService.Add(issue);
                return RedirectToAction("MyIssues");
            }
            else
            {
                ViewBag.users = await _userManager.Users.ToListAsync();
                ViewBag.user = await _userManager.GetUserAsync(HttpContext.User);
                ViewBag.projects = _projectService.GetAll();
                return View();
            }

        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.users = await _userManager.Users.ToListAsync();
            ViewBag.user = await _userManager.GetUserAsync(HttpContext.User);
            ViewBag.projects = _projectService.GetAll();
            var issues = _issueService.Get(id);
            return View(issues);
        }

        [HttpPost]
        public async Task<IActionResult> Update(IssueModel issue)
        {
			_issueService.Update(issue);
			return RedirectToAction("MyIssues");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {

			_issueService.Remove(id);

			// Get the URL of the previous page
			string previousUrl = Request.Headers["Referer"].ToString();
			// Redirect the user to the previous page
			return Redirect(previousUrl);
	    }
    }
}
