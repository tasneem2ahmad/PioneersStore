using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pioneers.DAL.Migrations
{
    /// <inheritdoc />
    public partial class _AddShownFeature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsShownUser",
                table: "Departments",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsShownUser",
                table: "Departments");
        }
    }
}
