using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.loja.Migrations
{
    /// <inheritdoc />
    public partial class FileManager : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "FileDirectory",
                columns: table => new
                {
                    FileDirectoryId = table.Column<int>(type: "int", nullable: false),
                    DirectoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileDirectory", x => x.FileDirectoryId);
          
                });

            migrationBuilder.CreateTable(
                name: "FileStorage",
                columns: table => new
                {
                    FileStorageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Length = table.Column<long>(type: "bigint", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileDirectoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileStorage", x => x.FileStorageId);
                    table.ForeignKey(
                      name: "FK_FileStorage_FileDirectory_FileDirectoryId",
                      column: x => x.FileDirectoryId,
                      principalTable: "FileDirectory",
                      principalColumn: "FileDirectoryId",
                      onDelete: ReferentialAction.Restrict);
                });


       
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "FileStorage");
            migrationBuilder.DropTable(
                name: "FileDirectory");


        }
    }
}
