using IssueManagement.Models;

namespace IssueManagement.Business.Abstract
{
	public interface ICommentService
	{
		public void Add(CommentModel descriptionModel);
		public void Update(CommentModel descriptionModel);
		public void Remove(int id);
		public CommentModel Get(int id);

		public List<CommentModel> GetAll();
	}
}
