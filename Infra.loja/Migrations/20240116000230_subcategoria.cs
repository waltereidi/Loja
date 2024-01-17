using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.loja.Migrations
{
    /// <inheritdoc />
    public partial class subcategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_RequestOrders_Products",
            //    table: "RequestOrders_Products");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_productsStore",
            //    table: "productsStore");

            //migrationBuilder.RenameTable(
            //    name: "RequestOrders_Products",
            //    newName: "RequestOrdersProducts");

            //migrationBuilder.RenameTable(
            //    name: "productsStore",
            //    newName: "productsStorage");

            //migrationBuilder.RenameColumn(
            //    name: "CateogoriesId",
            //    table: "productsCategories",
            //    newName: "CategoriesId");

            //migrationBuilder.RenameColumn(
            //    name: "CateogoriesId",
            //    table: "categoriesPromotion",
            //    newName: "CategoriesId");

          
            //migrationBuilder.AlterColumn<int>(
            //    name: "RequestOrdersProductsId",
            //    table: "RequestOrdersProducts",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .OldAnnotation("SqlServer:Identity", "1, 1");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_RequestOrdersProducts",
            //    table: "RequestOrdersProducts",
            //    column: "RequestOrdersProductsId");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_productsStorage",
            //    table: "productsStorage",
            //    column: "ProductsStorageId");

           
            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    SubCategoriesId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", nullable: false),
                    ID_Categories = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.SubCategoriesId);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories",
                        column: x => x.SubCategoriesId,
                        principalTable: "categories",
                        principalColumn: "CategoriesId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubSubCategories",
                columns: table => new
                {
                    SubSubCategoriesId = table.Column<int>(type: "int", nullable: false),
                    SubCategoriesId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubSubCategories", x => x.SubSubCategoriesId);
                    table.ForeignKey(
                        name: "FK_SubSubCategories_SubCategories",
                        column: x => x.SubSubCategoriesId,
                        principalTable: "SubCategories",
                        principalColumn: "SubCategoriesId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
               name: "ProductsSubCategories",
               columns: table => new
               {
                   ProductsSubCategoriesId = table.Column<int>(type: "int", nullable: false),
                   ProductsId = table.Column<int>(type: "int", nullable: false),
                   SubCategoriesId = table.Column<int>(type: "int", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_ProductsSubCategories", x => x.ProductsSubCategoriesId);
                   table.ForeignKey(
                       name: "FK_ProductsSubCategories_Products",
                       column: x => x.ProductsId,
                       principalTable: "products",
                       principalColumn: "ProductsId",
                       onDelete: ReferentialAction.Cascade);
                   table.ForeignKey(
                       name: "FK_ProductsSubCategories_Categories",
                       column: x => x.SubCategoriesId,
                       principalTable: "SubCategories",
                       principalColumn: "SubCategoriesId",
                       onDelete: ReferentialAction.Cascade);
               });

            migrationBuilder.CreateTable(
                name: "ProductsSubSubCategories",
                columns: table => new
                {
                    ProductsSubSubCategoriesId = table.Column<int>(type: "int", nullable: false),
                    SubSubCategoriesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsSubSubCategories", x => x.ProductsSubSubCategoriesId);
                    table.ForeignKey(
                        name: "FK_ProductsSubSubCategories_Products",
                        column: x => x.ProductsId,
                        principalTable: "products",
                        principalColumn: "ProductsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsSubSubCategories_SubSubCategories",
                        column: x => x.SubSubCategoriesId,
                        principalTable: "SubSubCategories",
                        principalColumn: "SubSubCategoriesId",
                        onDelete: ReferentialAction.Cascade);
                });
            

            migrationBuilder.AlterColumn<int>(
                name: "ProductsSubCategoriesId",
                table: "productsSubCategories",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");
            migrationBuilder.AlterColumn<int>(
                name: "ProductsSubSubCategoriesId",
                table: "productsSubCategories",
                type: "int",
                nullable: false,
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1 , 1");
            migrationBuilder.AlterColumn<int>(
                name: "SubSubCategoriesId",
                table: "SubSubCategories",
                type: "int",
                nullable: false,
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1 , 1");
            migrationBuilder.AlterColumn<int>(
                name: "SubCategoriesId",
                table: "SubCategories",
                type: "int",
                nullable: false,
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1 , 1");



            //migrationBuilder.CreateIndex(
            //    name: "IX_productsPrices_ProductsId",
            //    table: "productsPrices",
            //    column: "ProductsId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_permissionsRelation_PermissionsGroupId",
            //    table: "permissionsRelation",
            //    column: "PermissionsGroupId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_permissionsRelation_PermissionsId",
            //    table: "permissionsRelation",
            //    column: "PermissionsId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_clientsProductsCart_ClientsId",
            //    table: "clientsProductsCart",
            //    column: "ClientsId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_clients_PermissionsGroupId",
            //    table: "clients",
            //    column: "PermissionsGroupId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_categoriesPromotion_CategoriesId",
            //    table: "categoriesPromotion",
            //    column: "CategoriesId",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_productsStorage_ProductsId",
            //    table: "productsStorage",
            //    column: "ProductsId",
            //    unique: true);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_categoriesPromotion_categories_CategoriesId",
            //    table: "categoriesPromotion",
            //    column: "CategoriesId",
            //    principalTable: "categories",
            //    principalColumn: "CategoriesId",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_clients_permissionsGroup_PermissionsGroupId",
            //    table: "clients",
            //    column: "PermissionsGroupId",
            //    principalTable: "permissionsGroup",
            //    principalColumn: "PermissionsGroupId",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_clientsProductsCart_clients_ClientsId",
            //    table: "clientsProductsCart",
            //    column: "ClientsId",
            //    principalTable: "clients",
            //    principalColumn: "ClientsId",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_permissionsRelation_permissionsGroup_PermissionsGroupId",
            //    table: "permissionsRelation",
            //    column: "PermissionsGroupId",
            //    principalTable: "permissionsGroup",
            //    principalColumn: "PermissionsGroupId",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_permissionsRelation_permissions_PermissionsId",
            //    table: "permissionsRelation",
            //    column: "PermissionsId",
            //    principalTable: "permissions",
            //    principalColumn: "PermissionsId",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_products_RequestOrdersProducts_ProductsId",
            //    table: "products",
            //    column: "ProductsId",
            //    principalTable: "RequestOrdersProducts",
            //    principalColumn: "RequestOrdersProductsId",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_products_clientsProductsCart_ProductsId",
            //    table: "products",
            //    column: "ProductsId",
            //    principalTable: "clientsProductsCart",
            //    principalColumn: "ClientsProductsCartId",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_productsCategories_products_ProductsCategoriesId",
            //    table: "productsCategories",
            //    column: "ProductsCategoriesId",
            //    principalTable: "products",
            //    principalColumn: "ProductsId",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_productsPrices_products_ProductsId",
            //    table: "productsPrices",
            //    column: "ProductsId",
            //    principalTable: "products",
            //    principalColumn: "ProductsId",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_productsStorage_products_ProductsId",
            //    table: "productsStorage",
            //    column: "ProductsId",
            //    principalTable: "products",
            //    principalColumn: "ProductsId",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_RequestOrdersProducts_requestOrders_RequestOrdersProductsId",
            //    table: "RequestOrdersProducts",
            //    column: "RequestOrdersProductsId",
            //    principalTable: "requestOrders",
            //    principalColumn: "RequestOrdersId",
            //    onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categoriesPromotion_categories_CategoriesId",
                table: "categoriesPromotion");

            migrationBuilder.DropForeignKey(
                name: "FK_clients_permissionsGroup_PermissionsGroupId",
                table: "clients");

            migrationBuilder.DropForeignKey(
                name: "FK_clientsProductsCart_clients_ClientsId",
                table: "clientsProductsCart");

            migrationBuilder.DropForeignKey(
                name: "FK_permissionsRelation_permissionsGroup_PermissionsGroupId",
                table: "permissionsRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_permissionsRelation_permissions_PermissionsId",
                table: "permissionsRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_products_RequestOrdersProducts_ProductsId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_clientsProductsCart_ProductsId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_productsCategories_products_ProductsCategoriesId",
                table: "productsCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_productsPrices_products_ProductsId",
                table: "productsPrices");

            migrationBuilder.DropForeignKey(
                name: "FK_productsStorage_products_ProductsId",
                table: "productsStorage");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestOrdersProducts_requestOrders_RequestOrdersProductsId",
                table: "RequestOrdersProducts");

            migrationBuilder.DropTable(
                name: "ProductsSubCategories");

            migrationBuilder.DropTable(
                name: "ProductsSubSubCategories");

            migrationBuilder.DropTable(
                name: "SubSubCategories");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropIndex(
                name: "IX_productsPrices_ProductsId",
                table: "productsPrices");

            migrationBuilder.DropIndex(
                name: "IX_permissionsRelation_PermissionsGroupId",
                table: "permissionsRelation");

            migrationBuilder.DropIndex(
                name: "IX_permissionsRelation_PermissionsId",
                table: "permissionsRelation");

            migrationBuilder.DropIndex(
                name: "IX_clientsProductsCart_ClientsId",
                table: "clientsProductsCart");

            migrationBuilder.DropIndex(
                name: "IX_clients_PermissionsGroupId",
                table: "clients");

            migrationBuilder.DropIndex(
                name: "IX_categoriesPromotion_CategoriesId",
                table: "categoriesPromotion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestOrdersProducts",
                table: "RequestOrdersProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productsStorage",
                table: "productsStorage");

            migrationBuilder.DropIndex(
                name: "IX_productsStorage_ProductsId",
                table: "productsStorage");

            migrationBuilder.RenameTable(
                name: "RequestOrdersProducts",
                newName: "RequestOrders_Products");

            migrationBuilder.RenameTable(
                name: "productsStorage",
                newName: "productsStore");

            migrationBuilder.RenameColumn(
                name: "CategoriesId",
                table: "productsCategories",
                newName: "CateogoriesId");

            migrationBuilder.RenameColumn(
                name: "CategoriesId",
                table: "categoriesPromotion",
                newName: "CateogoriesId");

            //migrationBuilder.AlterColumn<int>(
            //    name: "ProductsCategoriesId",
            //    table: "productsCategories",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .Annotation("SqlServer:Identity", "1, 1");

            //migrationBuilder.AlterColumn<int>(
            //    name: "ProductsId",
            //    table: "products",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .Annotation("SqlServer:Identity", "1, 1");

            //migrationBuilder.AlterColumn<int>(
            //    name: "RequestOrdersProductsId",
            //    table: "RequestOrders_Products",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestOrders_Products",
                table: "RequestOrders_Products",
                column: "RequestOrdersProductsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_productsStore",
                table: "productsStore",
                column: "ProductsStorageId");
        }
    }
}
