using Microsoft.EntityFrameworkCore.Migrations;

namespace Send_and_track.Migrations
{
    public partial class Percent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Percent",
                table: "Attachment",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Percent",
                table: "Attachment",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
