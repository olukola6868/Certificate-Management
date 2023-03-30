using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CertificateManagement.Migrations
{
    public partial class initialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Organizations",
                newName: "IsApproved");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsApproved",
                table: "Organizations",
                newName: "IsActive");
        }
    }
}
