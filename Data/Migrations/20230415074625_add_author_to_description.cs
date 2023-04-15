using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IssueManagement.Data.Migrations
{
    public partial class add_author_to_description : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DescriptionModels_IssueModels_issueModelId",
                table: "DescriptionModels");

            migrationBuilder.RenameColumn(
                name: "time",
                table: "DescriptionModels",
                newName: "Time");

            migrationBuilder.RenameColumn(
                name: "issueModelId",
                table: "DescriptionModels",
                newName: "IssueModelId");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "DescriptionModels",
                newName: "Description");

            migrationBuilder.RenameIndex(
                name: "IX_DescriptionModels_issueModelId",
                table: "DescriptionModels",
                newName: "IX_DescriptionModels_IssueModelId");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "DescriptionModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_DescriptionModels_IssueModels_IssueModelId",
                table: "DescriptionModels",
                column: "IssueModelId",
                principalTable: "IssueModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DescriptionModels_IssueModels_IssueModelId",
                table: "DescriptionModels");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "DescriptionModels");

            migrationBuilder.RenameColumn(
                name: "Time",
                table: "DescriptionModels",
                newName: "time");

            migrationBuilder.RenameColumn(
                name: "IssueModelId",
                table: "DescriptionModels",
                newName: "issueModelId");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "DescriptionModels",
                newName: "description");

            migrationBuilder.RenameIndex(
                name: "IX_DescriptionModels_IssueModelId",
                table: "DescriptionModels",
                newName: "IX_DescriptionModels_issueModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_DescriptionModels_IssueModels_issueModelId",
                table: "DescriptionModels",
                column: "issueModelId",
                principalTable: "IssueModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
