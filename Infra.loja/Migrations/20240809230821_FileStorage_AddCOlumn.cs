using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.loja.Migrations
{
    /// <inheritdoc />
    public partial class FileStorage_AddCOlumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "FileStorage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OriginalName",
                table: "FileStorage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "FileStorage");

            migrationBuilder.DropColumn(
                name: "OriginalName",
                table: "FileStorage");
        }
    }
}
