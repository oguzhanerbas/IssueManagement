using IssueManagement.Business.Abstract;
using IssueManagement.Data;
using IssueManagement.Models;

namespace IssueManagement.Business.Concrete
{
	public class CommentManager : ICommentService
	{
		private readonly ApplicationDbContext _context;
		public CommentManager(ApplicationDbContext applicationDbContext)
		{
			_context = applicationDbContext;
		}
		public void Add(CommentModel descriptionModel)
		{
			var result = _context.DescriptionModels.FirstOrDefault(p => p.Id == descriptionModel.Id);
			if (result == null)
			{
				_context.DescriptionModels.Add(descriptionModel);
				_context.SaveChanges();
			}
			else
			{

			}
		}
		public void Update(CommentModel descriptionModel)
		{
			var result = _context.DescriptionModels.FirstOrDefault(p => p.Id == descriptionModel.Id);
			if (result == null)
			{

			}
			else
			{
				result.Description = descriptionModel.Description;
				_context.SaveChanges();
			}
		}

		public void Remove(int id)
		{
			var result = _context.DescriptionModels.FirstOrDefault(p => p.Id == id);
			if (result == null)
			{

			}
			else
			{
				_context.DescriptionModels.Remove(result);
				_context.SaveChanges();
			}
		}

		public CommentModel Get(int id)
		{
			var result = _context.DescriptionModels.FirstOrDefault(p => p.Id == id);
			return result;
		}

		public List<CommentModel> GetAll()
		{
			var result = _context.DescriptionModels.ToList();
			return result;
		}




	}
}
