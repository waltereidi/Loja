using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.loja.Migrations
{
    /// <inheritdoc />
    public partial class FileManagerChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "ValidExtensions",
                table: "FileDirectory");

            migrationBuilder.DropColumn(
                name: "FileStorageId",
                table: "categories");

            migrationBuilder.AddColumn<string>(
                name: "ImageId",
                table: "products",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "FileStorage",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "FileProperties",
                table: "FileStorage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FileCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FileStorageId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileCategories_FileStorage_FileStorageId",
                        column: x => x.FileStorageId,
                        principalTable: "FileStorage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FileCategories_categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_ImageId",
                table: "products",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_FileCategories_CategoriesId",
                table: "FileCategories",
                column: "CategoriesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FileCategories_FileStorageId",
                table: "FileCategories",
                column: "FileStorageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_products_FileStorage_ImageId",
                table: "products",
                column: "ImageId",
                principalTable: "FileStorage",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_FileStorage_ImageId",
                table: "products");

            migrationBuilder.DropTable(
                name: "FileCategories");

            migrationBuilder.DropIndex(
                name: "IX_products_ImageId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "FileProperties",
                table: "FileStorage");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "FileStorage",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "ValidExtensions",
                table: "FileDirectory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
                column: "FileStorageId",
                unique: true,
                filter: "[FileStorageId] IS NOT NULL");

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
    }
}
