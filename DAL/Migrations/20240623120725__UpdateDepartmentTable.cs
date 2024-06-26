using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pioneers.DAL.Migrations
{
    /// <inheritdoc />
    public partial class _UpdateDepartmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EnglishName",
                table: "Departments",
                type: "longtext",
                nullable: true);
            migrationBuilder.DropColumn(
            name: "Name",
            table: "Departments");
            migrationBuilder.AddColumn<string>(
                name: "ArabicName",
                table: "Departments",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Departments",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Departments",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Departments",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Departments",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArabicName",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Departments");

            migrationBuilder.DropColumn(
           name: "EnglishName",
           table: "Departments");
            migrationBuilder.AddColumn<string>(
            name: "Name",
            table: "Departments",
            type: "longtext",
            nullable: false,
            defaultValue: "");
        }
    }
}
