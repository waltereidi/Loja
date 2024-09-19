using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.loja.Migrations
{
    /// <inheritdoc />
    public partial class FileDirectory_AddDirectoryRestriction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_categories_FileStorageId",
                table: "categories");

            migrationBuilder.AddColumn<string>(
                name: "Restriction",
                table: "FileDirectory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_categories_FileStorageId",
                table: "categories",
                column: "FileStorageId",
                unique: true,
                filter: "[FileStorageId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_categories_FileStorageId",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "Restriction",
                table: "FileDirectory");

            migrationBuilder.CreateIndex(
                name: "IX_categories_FileStorageId",
                table: "categories",
                column: "FileStorageId");
        }
    }
}
