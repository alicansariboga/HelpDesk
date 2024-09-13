using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpDesk.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_10_ticketDocument_fileUpload : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "FileData",
                table: "TicketDocuments",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<int>(
                name: "FileType",
                table: "TicketDocuments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileData",
                table: "TicketDocuments");

            migrationBuilder.DropColumn(
                name: "FileType",
                table: "TicketDocuments");
        }
    }
}
