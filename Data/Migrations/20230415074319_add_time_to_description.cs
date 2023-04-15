using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IssueManagement.Data.Migrations
{
    public partial class add_time_to_description : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "DescriptionModels",
                newName: "description");

            migrationBuilder.AddColumn<DateTime>(
                name: "time",
                table: "DescriptionModels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "time",
                table: "DescriptionModels");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "DescriptionModels",
                newName: "Description");
        }
    }
}
