using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarModelManagement.infra.Domain.Migrations
{
    /// <inheritdoc />
    public partial class first2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "companyAdminUsername",
                table: "Companymaster",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "companyAdminUsername",
                table: "Companymaster");
        }
    }
}
