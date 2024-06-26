using Microsoft.EntityFrameworkCore.Migrations;

public partial class _AddFeaturestoDepartment : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        // Add the new column for the rename
        migrationBuilder.AddColumn<string>(
            name: "EnglishName",
            table: "Departments",
            type: "longtext",
            nullable: false,
            defaultValue: "");

        // Copy data from the old column to the new column
        migrationBuilder.Sql("UPDATE Departments SET EnglishName = Name");

        // Drop the old column
        migrationBuilder.DropColumn(
            name: "Name",
            table: "Departments");

        // Add new columns
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

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        // Remove new columns
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

        // Add the old column back
        migrationBuilder.AddColumn<string>(
            name: "Name",
            table: "Departments",
            type: "longtext",
            nullable: false,
            defaultValue: "");

        // Copy data back to the old column
        migrationBuilder.Sql("UPDATE Departments SET Name = EnglishName");

        // Drop the new column
        migrationBuilder.DropColumn(
            name: "EnglishName",
            table: "Departments");
    }
}
