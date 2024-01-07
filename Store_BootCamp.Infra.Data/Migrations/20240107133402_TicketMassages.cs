using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store_BootCamp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class TicketMassages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tickets",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<int>(type: "int", nullable: true),
                    state = table.Column<bool>(type: "bit", nullable: false),
                    dateTime = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tickets", x => x.id);
                    table.ForeignKey(
                        name: "FK_tickets_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ticketsMassage",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<int>(type: "int", nullable: true),
                    TicketForId = table.Column<int>(type: "int", nullable: true),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAndTime = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ticketsMassage", x => x.id);
                    table.ForeignKey(
                        name: "FK_ticketsMassage_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ticketsMassage_tickets_TicketForId",
                        column: x => x.TicketForId,
                        principalTable: "tickets",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tickets_OwnerId",
                table: "tickets",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ticketsMassage_SenderId",
                table: "ticketsMassage",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ticketsMassage_TicketForId",
                table: "ticketsMassage",
                column: "TicketForId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ticketsMassage");

            migrationBuilder.DropTable(
                name: "tickets");
        }
    }
}
