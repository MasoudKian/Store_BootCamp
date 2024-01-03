using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store_BootCamp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Change_ConctactUsModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "File",
                table: "ContactUs",
                newName: "FileTicket");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileTicket",
                table: "ContactUs",
                newName: "File");
        }
    }
}
