using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpDesk.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_04_appUser_failedLogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FailedLoginCount",
                table: "AppUsers",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "FailedLoginCount",
                table: "AppUsers",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
