using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store_BootCamp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Create_ContactUsResponseModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResponseId",
                table: "ContactUs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ContactUsResponses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResponseMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUsResponses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactUs_ResponseId",
                table: "ContactUs",
                column: "ResponseId",
                unique: true,
                filter: "[ResponseId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactUs_ContactUsResponses_ResponseId",
                table: "ContactUs",
                column: "ResponseId",
                principalTable: "ContactUsResponses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactUs_ContactUsResponses_ResponseId",
                table: "ContactUs");

            migrationBuilder.DropTable(
                name: "ContactUsResponses");

            migrationBuilder.DropIndex(
                name: "IX_ContactUs_ResponseId",
                table: "ContactUs");

            migrationBuilder.DropColumn(
                name: "ResponseId",
                table: "ContactUs");
        }
    }
}
