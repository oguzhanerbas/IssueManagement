using IssueManagement.Business.Abstract;
using IssueManagement.Data;
using IssueManagement.Models;
using Microsoft.Build.Evaluation;

namespace IssueManagement.Business.Concrete
{
	public class ProjectManager : IProjectService
	{
		private readonly ApplicationDbContext _context;

		public ProjectManager(ApplicationDbContext context)
		{
			_context = context;
		}

		public void Add(ProjectModel project)
		{
			var result = _context.ProjectModels.FirstOrDefault(x => x.Id == project.Id);
			if (result == null) 
			{
                _context.ProjectModels.Add(project);
                _context.SaveChanges();
            }
			else
			{

			}
		}
		public void Update(ProjectModel project)
		{
			var result = _context.ProjectModels.FirstOrDefault(x => x.Id == project.Id);
			if (result == null)
			{
				// Hata işleme kodu burada
			}
			else
			{
				result.Name = project.Name;
				result.Author = project.Author;
				result.Time = project.Time;

				_context.SaveChanges();
			}
		}
		public void Remove(int id)
		{
			var project = _context.ProjectModels.FirstOrDefault(p=>p.Id == id);
			if (project == null)
			{
				
			}
			else
			{
				_context.ProjectModels.Remove(project);
				_context.SaveChanges();
			}
		}


		public ProjectModel Get(int id)
		{
			var project = _context.ProjectModels.FirstOrDefault(p=> p.Id == id);
			return project;
		}

		public List<ProjectModel> GetAll()
		{
			var allProject = _context.ProjectModels.ToList();
			return allProject;
		}



	}
}
