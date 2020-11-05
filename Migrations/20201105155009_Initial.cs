using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendAssignmentPt2.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(5, 2)", nullable: false),
                    ImageFileName = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Author = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Publisher = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Published = table.Column<short>(type: "SMALLINT", nullable: true),
                    ISBN = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Director = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    MovieReleased = table.Column<short>(type: "SMALLINT", nullable: true),
                    Artist = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Label = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    CDReleased = table.Column<short>(type: "SMALLINT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    TrackId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Length = table.Column<TimeSpan>(type: "TIME", nullable: false),
                    Composer = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.TrackId);
                    table.ForeignKey(
                        name: "FK_Tracks_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_ProductId",
                table: "Tracks",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
