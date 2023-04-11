using IssueManagement.Business.Abstract;
using IssueManagement.Data;
using IssueManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace IssueManagement.Business.Concrete
{
	public class IssueManager : IIssueService
	{
		private readonly ApplicationDbContext _context;
        public IssueManager(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public void Add(IssueModel issue)
		{
			var result = _context.IssueModels.FirstOrDefault(p=>p.Id == issue.Id);
			if (result == null)
			{

			}
			else
			{
				_context.IssueModels.Add(result);
				_context.SaveChanges();
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
				_context.IssueModels.Update(result);
				_context.SaveChanges();
			}
		}
		public void Remove(int id)
		{
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
