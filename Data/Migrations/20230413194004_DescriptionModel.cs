using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IssueManagement.Data.Migrations
{
    public partial class DescriptionModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "IssueModels");

            migrationBuilder.CreateTable(
                name: "DescriptionModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    issueModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescriptionModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DescriptionModels_IssueModels_issueModelId",
                        column: x => x.issueModelId,
                        principalTable: "IssueModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DescriptionModels_issueModelId",
                table: "DescriptionModels",
                column: "issueModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DescriptionModels");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "IssueModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
