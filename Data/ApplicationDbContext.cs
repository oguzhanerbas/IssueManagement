using IssueManagement.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IssueManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<IssueModel> IssueModels { get; set; }
        public DbSet<ProjectModel> ProjectModels { get; set; }

        public DbSet<CommentModel> DescriptionModels { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}