using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.loja.Migrations
{
    /// <inheritdoc />
    public partial class AddFileDirectory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "Referer",
                table: "FileDirectory",
                type: "nvarchar(120)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ValidExtensions",
                table: "FileDirectory",
                type: "nvarchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.Sql("insert into fileDirectory(DirectoryName, referer, ValidExtensions,created_at) values( 'testCase' ,'/swagger/index.html' ,'application/pdf' , current_timestamp)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Referer",
                table: "FileDirectory");

            migrationBuilder.DropColumn(
                name: "ValidExtensions",
                table: "FileDirectory");

        }
    }
}
