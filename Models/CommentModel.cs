using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IssueManagement.Models
{
	public class CommentModel
	{
		[Key]
		public int Id { get; set; }
        [Required(ErrorMessage = "Comment Field is Required")]
        public string Description { get; set; }
		public DateTime Time { get; set; }
		public string Author { get; set; }

		[NotMapped]
		[ValidateNever]
		public IssueModel IssueModel { get; set; }
        public int IssueModelId { get; set; }
    }
}
