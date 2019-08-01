using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reassigner.Migrations
{
    public partial class UpdatedTypes1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Completed",
                table: "ReassignmentEntries");

            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedTime",
                table: "ReassignmentEntries",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompletedTime",
                table: "ReassignmentEntries");

            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "ReassignmentEntries",
                nullable: false,
                defaultValue: false);
        }
    }
}
