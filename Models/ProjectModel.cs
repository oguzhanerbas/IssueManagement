using System.ComponentModel.DataAnnotations;

namespace IssueManagement.Models
{
    public class ProjectModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Issue Name Field is Required")]
        public string Name { get; set; }
        [Required]
        public string Author { get; set; }
        public DateTime Time { get; set; }

    }
}
