using Microsoft.EntityFrameworkCore.Migrations;

namespace Employee.Data.Migrations
{
    public partial class UpdateEmpTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                schema: "Administration",
                table: "Employee",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "Administration",
                table: "Employee",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "Administration",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "LastName",
                schema: "Administration",
                table: "Employee",
                newName: "FullName");
        }
    }
}
