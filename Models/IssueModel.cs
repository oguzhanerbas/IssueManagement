using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IssueManagement.Models
{
    public class IssueModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Issue Name Field is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Author Field is Required")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Assign Field is Required")]
        public string Assign { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required(ErrorMessage = "Project Field is Required")]
        public int ProjectModelId { get; set; }

        [NotMapped]
        [ValidateNever]
        public ProjectModel ProjectModel { get; set; }
    }
}
