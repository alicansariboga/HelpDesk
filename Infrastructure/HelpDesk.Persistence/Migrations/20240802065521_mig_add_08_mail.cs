using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpDesk.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_08_mail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketDocuments_Tickets_TicketId",
                table: "TicketDocuments");

            migrationBuilder.AlterColumn<int>(
                name: "TicketId",
                table: "TicketDocuments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MailId",
                table: "TicketDocuments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Mails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Receiver = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mails", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketDocuments_MailId",
                table: "TicketDocuments",
                column: "MailId");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketDocuments_Mails_MailId",
                table: "TicketDocuments",
                column: "MailId",
                principalTable: "Mails",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketDocuments_Tickets_TicketId",
                table: "TicketDocuments",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketDocuments_Mails_MailId",
                table: "TicketDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketDocuments_Tickets_TicketId",
                table: "TicketDocuments");

            migrationBuilder.DropTable(
                name: "Mails");

            migrationBuilder.DropIndex(
                name: "IX_TicketDocuments_MailId",
                table: "TicketDocuments");

            migrationBuilder.DropColumn(
                name: "MailId",
                table: "TicketDocuments");

            migrationBuilder.AlterColumn<int>(
                name: "TicketId",
                table: "TicketDocuments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketDocuments_Tickets_TicketId",
                table: "TicketDocuments",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
