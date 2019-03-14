using Microsoft.EntityFrameworkCore.Migrations;

namespace Send_and_track.Migrations
{
    public partial class Percents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TotalPage",
                table: "Attachment",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "Percent",
                table: "Attachment",
                nullable: true,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TotalPage",
                table: "Attachment",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Percent",
                table: "Attachment",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);
        }
    }
}
