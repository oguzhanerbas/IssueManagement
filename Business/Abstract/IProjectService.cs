using IssueManagement.Models;
using Microsoft.Build.Evaluation;

namespace IssueManagement.Business.Abstract
{
	public interface IProjectService
	{
		public void Add(ProjectModel project);
		public void Update(ProjectModel project);
		public void Remove(int id);
		public ProjectModel Get(int id);
		public List<ProjectModel> GetAll();

    }
}
