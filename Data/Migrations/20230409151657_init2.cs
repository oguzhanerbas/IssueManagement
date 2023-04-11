using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IssueManagement.Data.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectModels_IssueModels_IssueModelId",
                table: "ProjectModels");

            migrationBuilder.DropIndex(
                name: "IX_ProjectModels_IssueModelId",
                table: "ProjectModels");

            migrationBuilder.DropColumn(
                name: "IssueModelId",
                table: "ProjectModels");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProjectModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "IssueModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProjectModelId",
                table: "IssueModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_IssueModels_ProjectModelId",
                table: "IssueModels",
                column: "ProjectModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_IssueModels_ProjectModels_ProjectModelId",
                table: "IssueModels",
                column: "ProjectModelId",
                principalTable: "ProjectModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssueModels_ProjectModels_ProjectModelId",
                table: "IssueModels");

            migrationBuilder.DropIndex(
                name: "IX_IssueModels_ProjectModelId",
                table: "IssueModels");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProjectModels");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "IssueModels");

            migrationBuilder.DropColumn(
                name: "ProjectModelId",
                table: "IssueModels");

            migrationBuilder.AddColumn<int>(
                name: "IssueModelId",
                table: "ProjectModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectModels_IssueModelId",
                table: "ProjectModels",
                column: "IssueModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectModels_IssueModels_IssueModelId",
                table: "ProjectModels",
                column: "IssueModelId",
                principalTable: "IssueModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
