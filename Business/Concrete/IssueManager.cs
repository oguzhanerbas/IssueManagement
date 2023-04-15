using IssueManagement.Business.Abstract;
using IssueManagement.Data;
using IssueManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace IssueManagement.Business.Concrete
{
	public class IssueManager : IIssueService
	{
		private readonly ApplicationDbContext _context;
		private readonly ICommentService _commentService;
        public IssueManager(ApplicationDbContext applicationDbContext, ICommentService commentService)
        {
            _context = applicationDbContext;
			_commentService = commentService;
        }
        public void Add(IssueModel issue)
		{
			var result = _context.IssueModels.FirstOrDefault(p=>p.Id == issue.Id);
			if (result == null)
			{
                _context.IssueModels.Add(issue);
                _context.SaveChanges();
            }
			else
			{

			}
		}
		public void Update(IssueModel issue)
		{
			var result = _context.IssueModels.FirstOrDefault(p=>p.Id == issue.Id);
			if (result == null)
			{

			}
			else
			{
                result.Name = issue.Name;
                result.Author = issue.Author;
                result.Time = issue.Time;
				result.Assign = issue.Assign;
				result.ProjectModelId = issue.ProjectModelId;
                _context.SaveChanges();
            }
		}
		public void Remove(int id)
		{
			var comments = _commentService.GetAll().Where(p=>p.IssueModelId == id);
			foreach (var comment in comments)
			{
				_commentService.Remove(comment.Id);
			}
			var result = _context.IssueModels.FirstOrDefault(p=> p.Id == id);
			if (result == null)
			{

			}
			else
			{
				_context.IssueModels.Remove(result);
				_context.SaveChanges();
			}
		}
		public IssueModel Get(int id)
		{
			var result = _context.IssueModels.FirstOrDefault(p=>p.Id==id);
			return result;
		}

		public List<IssueModel> GetAll()
		{
			var result = _context.IssueModels.ToList();
			return result;
		}

	}
}
