using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.loja.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.CategoriesId);
                });

            migrationBuilder.CreateTable(
               name: "products",
               columns: table => new
               {
                   ProductsId = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                   Description = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                   Ean = table.Column<long>(type: "bigint", nullable: true),
                   Sku = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                   Created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                   Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_products", x => x.ProductsId);
               });

            migrationBuilder.CreateTable(
                name: "categoriesPromotion",
                columns: table => new
                {
                    CategoriesPromotionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoriesPromotion", x => x.CategoriesPromotionId);
                    table.ForeignKey(
                     name: "FK_CategoriesPromotion_Categories_CategoriesId",
                     column: x => x.CategoriesId,
                     principalTable: "Categories",
                     principalColumn: "CategoriesId",
                     onDelete: ReferentialAction.Restrict);
                });

           

            migrationBuilder.CreateTable(
                name: "clientsProductsCart",
                columns: table => new
                {
                    ClientsProductsCartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    ClientsId = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientsProductsCart", x => x.ClientsProductsCartId);
                    table.ForeignKey(
                            name: "FK_ClientsProductsCart_Products", 
                            column :  x => x.ProductsId,
                            principalTable: "Products" , 
                            principalColumn:"ProductsId" , 
                            onDelete: ReferentialAction.Restrict
                        ); 

                });

            migrationBuilder.CreateTable(
                name: "permissions",
                columns: table => new
                {
                    PermissionsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissions", x => x.PermissionsId);
                });

            migrationBuilder.CreateTable(
                name: "permissionsGroup",
                columns: table => new
                {
                    PermissionsGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissionsGroup", x => x.PermissionsGroupId);
                });

            migrationBuilder.CreateTable(
                name: "permissionsRelation",
                columns: table => new
                {
                    PermissionsRelationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionsGroupId = table.Column<int>(type: "int", nullable: false),
                    PermissionsId = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },

                constraints: table =>
                {
                    table.PrimaryKey("PK_permissionsRelation", x => x.PermissionsRelationId);
                    table.ForeignKey(
                        name: "FK_PermissionsRelation_PermissionsGroup_PermissionsGroupId",
                        column: x => x.PermissionsGroupId , 
                        principalTable:"PermissionsGroup" , 
                        principalColumn: "PermissionsGroupId" 
                        );
                    table.ForeignKey(
                        name: "FK_PermissionsRelation_Permissions_PermissionsId",
                        column: x => x.PermissionsId,
                        principalTable:"Permissions",
                        principalColumn: "PermissionsId"
                        ) ;
                });
            migrationBuilder.CreateTable(
               name: "clients",
               columns: table => new
               {
                   ClientsId = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   Email = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: false),
                   Password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                   PermissionsGroupId = table.Column<int>(type: "int", nullable: false),
                   Created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                   Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_clients", x => x.ClientsId);
                   table.ForeignKey(
                       name: "FK_Clients_PermissionsGroup_PermissionsGroupId",
                       column: x => x.PermissionsGroupId,
                       principalTable: "PermissionsGroup",
                       principalColumn: "PermissionsGroupId",
                       onDelete: ReferentialAction.Restrict
                       );
               });
            migrationBuilder.CreateTable(
                name: "prices",
                columns: table => new
                {
                    PricesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prices", x => x.PricesId);
                });


            migrationBuilder.CreateTable(
                name: "productsCategories",
                columns: table => new
                {
                    ProductsCategoriesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    CateogoriesId = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productsCategories", x => x.ProductsCategoriesId);
                    table.ForeignKey(
                        name: "FK_ProductsCategories_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "ProductsId"
                        );
                    table.ForeignKey(
                        name: "FK_ProductsCategories_Categories_CategoriesId", 
                        column: x => x.CateogoriesId, 
                        principalTable: "Categories" , 
                        principalColumn: "CategoriesId" 
                        );
                });

            migrationBuilder.CreateTable(
                name: "productsPrices",
                columns: table => new
                {
                    ProductsPriceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    PricesId = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productsPrices", x => x.ProductsPriceId);
                    table.ForeignKey(
                        name: "FK_ProductsPrices_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "ProductsId");
                    table.ForeignKey(
                        name: "FK_ProductsPrice_Prices_PricesId",  
                        column: x => x.PricesId,
                        principalTable:"Prices", 
                        principalColumn: "PricesId"
                        );
;                });

            migrationBuilder.CreateTable(
                name: "productsStorage",
                columns: table => new
                {
                    ProductsStorageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productsStore", x => x.ProductsStorageId);
                    table.ForeignKey(
                        name: "FK_ProductsStore_Products_ProductsId" , 
                        column: x => x.ProductsId,
                        principalTable: "Products", 
                        principalColumn: "ProductsId"
                        );
                });

           
            migrationBuilder.CreateTable(
                name: "requestOrders",
                columns: table => new
                {
                    RequestOrdersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrption = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requestOrders", x => x.RequestOrdersId);
                });

            migrationBuilder.CreateTable(
                name: "RequestOrdersProducts",
                columns: table => new
                {
                    RequestOrdersProductsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestOrdersId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestOrders_Products", x => x.RequestOrdersProductsId);
                    table.ForeignKey(
                        name: "FK_RequestOrdersProducts_Products_ProductsId" , 
                        column: x => x.ProductsId,
                        principalTable: "Products", 
                        principalColumn: "ProductsId"
                        );
                    table.ForeignKey(
                        name : "FK_RequestOrdersProducts_RequestOrders_RequestOrdersid", 
                        column: x => x.RequestOrdersId ,
                        principalTable: "RequestOrders" , 
                        principalColumn: "RequestOrdersId"
                        );
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "categoriesPromotion");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "clientsProductsCart");

            migrationBuilder.DropTable(
                name: "permissions");

            migrationBuilder.DropTable(
                name: "permissionsGroup");

            migrationBuilder.DropTable(
                name: "permissionsRelation");

            migrationBuilder.DropTable(
                name: "prices");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "productsCategories");

            migrationBuilder.DropTable(
                name: "productsPrices");

            migrationBuilder.DropTable(
                name: "productsStore");

            migrationBuilder.DropTable(
                name: "requestOrders");

            migrationBuilder.DropTable(
                name: "RequestOrdersProducts");
        }
    }
}
