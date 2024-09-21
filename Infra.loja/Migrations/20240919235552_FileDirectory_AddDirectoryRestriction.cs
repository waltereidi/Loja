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

            migrationBuilder.Sql("insert into fileDirectory(DirectoryName, referer, ValidExtensions,restriction,created_at) values( 'Store_Categories' ,'/Store/Categories/ChangePicture' ,'jpg;png;svg;webp;avif' , '{\"max\":2000000 , \"images\":{\"height\":200} }' , current_timestamp)");
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
