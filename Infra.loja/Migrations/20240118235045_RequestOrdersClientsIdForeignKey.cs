using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.loja.Migrations
{
    /// <inheritdoc />
    public partial class RequestOrdersClientsIdForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.AddColumn<int>(
                name: "ClientsId",
                table: "requestOrders",
                type: "int",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_requestOrders_Clients_RequestOrdersClientsId",
                table: "requestOrders",
                column: "ClientsId",
                principalTable: "clients",
                principalColumn: "ClientsId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
               name: "ClientsId",
               table: "requestOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_requestOrders_Clients_RequestOrdersClientsId",
                table: "requestOrders");
           
        }
    }
}
