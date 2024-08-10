using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.loja.Migrations
{
    /// <inheritdoc />
    public partial class CategoriesANDProducts_AddImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FileStorageId",
                table: "products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FileStorageId",
                table: "categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_FileStorageId",
                table: "products",
                column: "FileStorageId");

            migrationBuilder.CreateIndex(
                name: "IX_categories_FileStorageId",
                table: "categories",
                column: "FileStorageId");

            migrationBuilder.AddForeignKey(
                name: "FK_categories_FileStorage_FileStorageId",
                table: "categories",
                column: "FileStorageId",
                principalTable: "FileStorage",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_FileStorage_FileStorageId",
                table: "products",
                column: "FileStorageId",
                principalTable: "FileStorage",
                principalColumn: "Id");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categories_FileStorage_FileStorageId",
                table: "categories");

            migrationBuilder.DropForeignKey(
                name: "FK_products_FileStorage_FileStorageId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_FileStorageId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_categories_FileStorageId",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "FileStorageId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "FileStorageId",
                table: "categories");
        }
    }
}
