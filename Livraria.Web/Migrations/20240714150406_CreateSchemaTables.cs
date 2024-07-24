using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Livraria.Web.Migrations
{
    /// <inheritdoc />
    public partial class CreateSchemaTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_author",
                columns: table => new
                {
                    author_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    birth_date = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_author", x => x.author_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_seller",
                columns: table => new
                {
                    seller_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    seller_code = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_seller", x => x.seller_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_book",
                columns: table => new
                {
                    book_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Publisher = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    isbn = table.Column<int>(type: "int", nullable: false),
                    TotalPages = table.Column<int>(type: "int", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    summary = table.Column<string>(type: "LONGTEXT", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<double>(type: "double", nullable: false),
                    AuthorId = table.Column<long>(type: "bigint", nullable: false),
                    GenreId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_book", x => x.book_id);
                    table.ForeignKey(
                        name: "fk_book_author_id",
                        column: x => x.AuthorId,
                        principalTable: "tb_author",
                        principalColumn: "author_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_book_genre_id",
                        column: x => x.GenreId,
                        principalTable: "tb_genre",
                        principalColumn: "genre_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_sale",
                columns: table => new
                {
                    sale_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    sale_total = table.Column<double>(type: "DOUBLE", nullable: false),
                    SellerId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_sale", x => x.sale_id);
                    table.ForeignKey(
                        name: "fk_sale_seller_id",
                        column: x => x.SellerId,
                        principalTable: "tb_seller",
                        principalColumn: "seller_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_stock",
                columns: table => new
                {
                    stock_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BookId = table.Column<long>(type: "bigint", nullable: false),
                    Qty = table.Column<double>(type: "DOUBLE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_stock", x => x.stock_id);
                    table.ForeignKey(
                        name: "fk_stock_book_id",
                        column: x => x.BookId,
                        principalTable: "tb_book",
                        principalColumn: "book_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_sale_book",
                columns: table => new
                {
                    book_id = table.Column<long>(type: "bigint", nullable: false),
                    sale_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_sale_book", x => new { x.sale_id, x.book_id });
                    table.ForeignKey(
                        name: "FK_tb_sale_book_tb_book_book_id",
                        column: x => x.book_id,
                        principalTable: "tb_book",
                        principalColumn: "book_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_sale_book_sales",
                        column: x => x.sale_id,
                        principalTable: "tb_sale",
                        principalColumn: "sale_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_tb_book_AuthorId",
                table: "tb_book",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_book_GenreId",
                table: "tb_book",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_sale_SellerId",
                table: "tb_sale",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_sale_book_book_id",
                table: "tb_sale_book",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_stock_BookId",
                table: "tb_stock",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_sale_book");

            migrationBuilder.DropTable(
                name: "tb_stock");

            migrationBuilder.DropTable(
                name: "tb_sale");

            migrationBuilder.DropTable(
                name: "tb_book");

            migrationBuilder.DropTable(
                name: "tb_seller");

            migrationBuilder.DropTable(
                name: "tb_author");
        }
    }
}
