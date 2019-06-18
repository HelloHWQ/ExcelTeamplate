using Microsoft.EntityFrameworkCore.Migrations;

namespace ExcelTeamplate.TeamplateDbContext.Migrations
{
    public partial class addcolforlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LogType",
                table: "Logs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogType",
                table: "Logs");
        }
    }
}
