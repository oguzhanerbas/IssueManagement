using System.ComponentModel.DataAnnotations;

namespace IssueManagement.Models
{
    public class IssueModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Issue Name Field is Required")]
        public string Name { get; set; }

        [Required]
        public string Author { get; set; }


        [Required(ErrorMessage = "Description Field is Required")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Assign Field is Required")]
        public string Assign { get; set; }

        [Required]
        public DateTime Time { get; set; }

        public int ProjectModelId { get; set; }
        public ProjectModel ProjectModel { get; set; }
    }
}
