using Microsoft.EntityFrameworkCore.Migrations;

namespace HRManager.Api.Migrations
{
    public partial class updateddb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Alerts",
                newName: "Archived");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Archived",
                table: "Alerts",
                newName: "Deleted");
        }
    }
}
