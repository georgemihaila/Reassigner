using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reassigner.Migrations
{
    public partial class UpdatedTypes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Rules",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "Rules",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastRan",
                table: "Rules",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Rules");

            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "Rules");

            migrationBuilder.DropColumn(
                name: "LastRan",
                table: "Rules");
        }
    }
}
