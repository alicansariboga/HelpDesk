using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpDesk.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_03_appUserRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "AppUserRoles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AppUserRoles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "AppUserRoles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "AppUserRoles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
