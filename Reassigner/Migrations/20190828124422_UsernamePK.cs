using Microsoft.EntityFrameworkCore.Migrations;

namespace Reassigner.Migrations
{
    public partial class UsernamePK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReassignmentEntries_Agents_AgentID",
                table: "ReassignmentEntries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Agents",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Agents");

            migrationBuilder.RenameColumn(
                name: "AgentID",
                table: "ReassignmentEntries",
                newName: "AgentUsername");

            migrationBuilder.RenameIndex(
                name: "IX_ReassignmentEntries_AgentID",
                table: "ReassignmentEntries",
                newName: "IX_ReassignmentEntries_AgentUsername");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Agents",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agents",
                table: "Agents",
                column: "Username");

            migrationBuilder.AddForeignKey(
                name: "FK_ReassignmentEntries_Agents_AgentUsername",
                table: "ReassignmentEntries",
                column: "AgentUsername",
                principalTable: "Agents",
                principalColumn: "Username",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReassignmentEntries_Agents_AgentUsername",
                table: "ReassignmentEntries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Agents",
                table: "Agents");

            migrationBuilder.RenameColumn(
                name: "AgentUsername",
                table: "ReassignmentEntries",
                newName: "AgentID");

            migrationBuilder.RenameIndex(
                name: "IX_ReassignmentEntries_AgentUsername",
                table: "ReassignmentEntries",
                newName: "IX_ReassignmentEntries_AgentID");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Agents",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "ID",
                table: "Agents",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agents",
                table: "Agents",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ReassignmentEntries_Agents_AgentID",
                table: "ReassignmentEntries",
                column: "AgentID",
                principalTable: "Agents",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
