using Microsoft.EntityFrameworkCore.Migrations;

namespace Reassigner.Migrations
{
    public partial class UpdatedTypes0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "ReassignmentEntries",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Completed",
                table: "ReassignmentEntries");
        }
    }
}
