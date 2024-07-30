using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpDesk.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_07_department_Location : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "StaffDepartments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StaffDepartments_LocationId",
                table: "StaffDepartments",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_StaffDepartments_Location_LocationId",
                table: "StaffDepartments",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaffDepartments_Location_LocationId",
                table: "StaffDepartments");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropIndex(
                name: "IX_StaffDepartments_LocationId",
                table: "StaffDepartments");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "StaffDepartments");
        }
    }
}
