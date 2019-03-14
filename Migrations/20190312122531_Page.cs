using Microsoft.EntityFrameworkCore.Migrations;

namespace Send_and_track.Migrations
{
    public partial class Page : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Percent",
                table: "Attachment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalPage",
                table: "Attachment",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Percent",
                table: "Attachment");

            migrationBuilder.DropColumn(
                name: "TotalPage",
                table: "Attachment");
        }
    }
}
