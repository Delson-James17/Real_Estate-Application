using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Real_Estate.Migrations
{
    public partial class secondcommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlImages",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlImages",
                table: "AspNetUsers");
        }
    }
}
