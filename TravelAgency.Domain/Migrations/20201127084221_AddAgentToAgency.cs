using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAgency.Domain.Migrations
{
    public partial class AddAgentToAgency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgencyId",
                table: "TravelAgents",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TravelAgents_AgencyId",
                table: "TravelAgents",
                column: "AgencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelAgents_Agencies_AgencyId",
                table: "TravelAgents",
                column: "AgencyId",
                principalTable: "Agencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TravelAgents_Agencies_AgencyId",
                table: "TravelAgents");

            migrationBuilder.DropIndex(
                name: "IX_TravelAgents_AgencyId",
                table: "TravelAgents");

            migrationBuilder.DropColumn(
                name: "AgencyId",
                table: "TravelAgents");
        }
    }
}
