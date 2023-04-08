using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Real_Estate.Migrations
{
    public partial class removeids : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Clients_ClientId",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Owners_OwnerId",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Properties_PropertyId",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_PropertyTypes_PropertyTypesId",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_ClientId",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_OwnerId",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_PropertyId",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_PropertyTypesId",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "PropertyTypesId",
                table: "Appointment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Appointment",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Appointment",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PropertyId",
                table: "Appointment",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PropertyTypesId",
                table: "Appointment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_ClientId",
                table: "Appointment",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_OwnerId",
                table: "Appointment",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_PropertyId",
                table: "Appointment",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_PropertyTypesId",
                table: "Appointment",
                column: "PropertyTypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Clients_ClientId",
                table: "Appointment",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Owners_OwnerId",
                table: "Appointment",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Properties_PropertyId",
                table: "Appointment",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_PropertyTypes_PropertyTypesId",
                table: "Appointment",
                column: "PropertyTypesId",
                principalTable: "PropertyTypes",
                principalColumn: "Id");
        }
    }
}
