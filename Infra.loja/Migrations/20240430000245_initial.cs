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
                name: "FileDirectory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DirectoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileDirectory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "permissionsGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissionsGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "prices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    Ean = table.Column<long>(type: "bigint", nullable: true),
                    Sku = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "requestOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    ClientsId = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requestOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "subSubCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubCategoriesId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subSubCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileStorage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Length = table.Column<long>(type: "bigint", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileDirectoryId = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileStorage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileStorage_FileDirectory_FileDirectoryId",
                        column: x => x.FileDirectoryId,
                        principalTable: "FileDirectory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PermissionsGroupId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_clients_permissionsGroup_PermissionsGroupId",
                        column: x => x.PermissionsGroupId,
                        principalTable: "permissionsGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "permissionsRelation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionsGroupId = table.Column<int>(type: "int", nullable: false),
                    PermissionsId = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissionsRelation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_permissionsRelation_permissionsGroup_PermissionsGroupId",
                        column: x => x.PermissionsGroupId,
                        principalTable: "permissionsGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_permissionsRelation_permissions_PermissionsId",
                        column: x => x.PermissionsId,
                        principalTable: "permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "clientsProductsCart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    ClientsId = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientsProductsCart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_clientsProductsCart_products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "productsPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    PricesId = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productsPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_productsPrices_products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "productsStorage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productsStorage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_productsStorage_products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductsSubCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    SubCategoriesId = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsSubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductsSubCategories_products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductsSubSubCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubSubCategoriesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsSubSubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductsSubSubCategories_products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RequestOrdersProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestOrdersId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestOrdersProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestOrdersProducts_products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequestOrdersProducts_requestOrders_RequestOrdersId",
                        column: x => x.RequestOrdersId,
                        principalTable: "requestOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

          

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
              name: "SubCategories",
              columns: table => new
              {
                  Id = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                  Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                  Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  CategoriesId = table.Column<int>(type: "int", nullable: false),
                  Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                  Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_SubCategories", x => x.Id);
                  table.ForeignKey(
                      name: "FK_SubCategories_Categories_Id",
                      column: x => x.CategoriesId,
                      principalTable: "Categories",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
              });

            migrationBuilder.CreateTable(
                name: "categoriesPromotion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoriesPromotion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_categoriesPromotion_categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "productsCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    CategoriesPromotionId = table.Column<int>(type: "int", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productsCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_productsCategories_categoriesPromotion_CategoriesPromotionId",
                        column: x => x.CategoriesPromotionId,
                        principalTable: "categoriesPromotion",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_productsCategories_products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.Sql("insert into permissions( name , created_at) values( 'testCase' , current_timestamp)");
            migrationBuilder.Sql("insert into permissionsgroup( name , created_at) values( 'testCase' , current_timestamp)");
            migrationBuilder.Sql("insert into permissionsRelation(permissionsGroupId,permissionsId, created_at) values( 1 , 1 , current_timestamp)");
            migrationBuilder.Sql("insert into clients( email , password , permissionsGroupId , firstName , lastName ,created_at ,address , phonenumber) values('testCase@email.com' , '123' , 1 ,'Test' , 'Case' ,current_timestamp , 'test address' , '010101')");
            migrationBuilder.Sql("insert into categories( name , description ,created_at) values( 'testCase' , 'description' , current_timestamp)");
            migrationBuilder.Sql("insert into subcategories( name , description ,created_at , categoriesId) values( 'testCase subCategories' , 'description' , current_timestamp , 1)");
            migrationBuilder.Sql("insert into subsubcategories( name , description ,created_at , subcategoriesId) values( 'testCase subSubCategories' , 'description' , current_timestamp , 1)");

            migrationBuilder.CreateIndex(
                name: "IX_categoriesPromotion_CategoriesId",
                table: "categoriesPromotion",
                column: "CategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_clients_PermissionsGroupId",
                table: "clients",
                column: "PermissionsGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_clientsProductsCart_ProductsId",
                table: "clientsProductsCart",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_FileStorage_FileDirectoryId",
                table: "FileStorage",
                column: "FileDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_permissionsRelation_PermissionsGroupId",
                table: "permissionsRelation",
                column: "PermissionsGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_permissionsRelation_PermissionsId",
                table: "permissionsRelation",
                column: "PermissionsId");

            migrationBuilder.CreateIndex(
                name: "IX_productsCategories_CategoriesPromotionId",
                table: "productsCategories",
                column: "CategoriesPromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_productsCategories_ProductsId",
                table: "productsCategories",
                column: "ProductsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_productsPrices_ProductsId",
                table: "productsPrices",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_productsStorage_ProductsId",
                table: "productsStorage",
                column: "ProductsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductsSubCategories_ProductsId",
                table: "ProductsSubCategories",
                column: "ProductsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductsSubSubCategories_ProductsId",
                table: "ProductsSubSubCategories",
                column: "ProductsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RequestOrdersProducts_ProductsId",
                table: "RequestOrdersProducts",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestOrdersProducts_RequestOrdersId",
                table: "RequestOrdersProducts",
                column: "RequestOrdersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "clientsProductsCart");

            migrationBuilder.DropTable(
                name: "FileStorage");

            migrationBuilder.DropTable(
                name: "permissionsRelation");

            migrationBuilder.DropTable(
                name: "prices");

            migrationBuilder.DropTable(
                name: "productsCategories");

            migrationBuilder.DropTable(
                name: "productsPrices");

            migrationBuilder.DropTable(
                name: "productsStorage");

            migrationBuilder.DropTable(
                name: "ProductsSubCategories");

            migrationBuilder.DropTable(
                name: "ProductsSubSubCategories");

            migrationBuilder.DropTable(
                name: "RequestOrdersProducts");

            migrationBuilder.DropTable(
                name: "FileDirectory");

            migrationBuilder.DropTable(
                name: "permissionsGroup");

            migrationBuilder.DropTable(
                name: "permissions");

            migrationBuilder.DropTable(
                name: "categoriesPromotion");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "requestOrders");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "subSubCategories");
        }
    }
}
