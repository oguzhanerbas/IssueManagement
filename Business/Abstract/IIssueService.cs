using IssueManagement.Models;

namespace IssueManagement.Business.Abstract
{
	public interface IIssueService
	{
		public void Add(IssueModel issue);
		public void Update(IssueModel issue);
		public void Remove(int id);
		public IssueModel Get(int id);
		public List<IssueModel> GetAll();
	}
}
