using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store_BootCamp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SetEmailForResponse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailUser",
                table: "ContactUsResponses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailUser",
                table: "ContactUsResponses");
        }
    }
}
