using Microsoft.EntityFrameworkCore.Migrations;

namespace Reassigner.Migrations
{
    public partial class AddedEntries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReassignmentEntries",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    TicketID = table.Column<string>(nullable: true),
                    AgentID = table.Column<string>(nullable: true),
                    RuleID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReassignmentEntries", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ReassignmentEntries_Agents_AgentID",
                        column: x => x.AgentID,
                        principalTable: "Agents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReassignmentEntries_Rules_RuleID",
                        column: x => x.RuleID,
                        principalTable: "Rules",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReassignmentEntries_Tickets_TicketID",
                        column: x => x.TicketID,
                        principalTable: "Tickets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReassignmentEntries_AgentID",
                table: "ReassignmentEntries",
                column: "AgentID");

            migrationBuilder.CreateIndex(
                name: "IX_ReassignmentEntries_RuleID",
                table: "ReassignmentEntries",
                column: "RuleID");

            migrationBuilder.CreateIndex(
                name: "IX_ReassignmentEntries_TicketID",
                table: "ReassignmentEntries",
                column: "TicketID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReassignmentEntries");
        }
    }
}
