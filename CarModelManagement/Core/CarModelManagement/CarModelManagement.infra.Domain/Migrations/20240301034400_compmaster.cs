using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarModelManagement.infra.Domain.Migrations
{
    /// <inheritdoc />
    public partial class compmaster : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyMasterID",
                table: "vehicleInverntory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_vehicleInverntory_CompanyMasterID",
                table: "vehicleInverntory",
                column: "CompanyMasterID");

            migrationBuilder.AddForeignKey(
                name: "FK_vehicleInverntory_Companymaster_CompanyMasterID",
                table: "vehicleInverntory",
                column: "CompanyMasterID",
                principalTable: "Companymaster",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vehicleInverntory_Companymaster_CompanyMasterID",
                table: "vehicleInverntory");

            migrationBuilder.DropIndex(
                name: "IX_vehicleInverntory_CompanyMasterID",
                table: "vehicleInverntory");

            migrationBuilder.DropColumn(
                name: "CompanyMasterID",
                table: "vehicleInverntory");
        }
    }
}
