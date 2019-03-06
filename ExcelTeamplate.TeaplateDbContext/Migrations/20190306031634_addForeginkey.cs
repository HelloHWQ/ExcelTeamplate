using Microsoft.EntityFrameworkCore.Migrations;

namespace ExcelTeamplate.TeamplateDbContext.Migrations
{
    public partial class addForeginkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AttachId",
                table: "Mains",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Mains_AttachId",
                table: "Mains",
                column: "AttachId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mains_Attaches_AttachId",
                table: "Mains",
                column: "AttachId",
                principalTable: "Attaches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mains_Attaches_AttachId",
                table: "Mains");

            migrationBuilder.DropIndex(
                name: "IX_Mains_AttachId",
                table: "Mains");

            migrationBuilder.DropColumn(
                name: "AttachId",
                table: "Mains");
        }
    }
}
