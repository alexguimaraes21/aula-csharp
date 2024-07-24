using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Livraria.Web.Migrations
{
    /// <inheritdoc />
    public partial class ChangeConstraintNamesFromSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_sale_book_tb_book_book_id",
                table: "tb_sale_book");

            migrationBuilder.DropForeignKey(
                name: "fk_sale_book_sales",
                table: "tb_sale_book");

            migrationBuilder.AddForeignKey(
                name: "fk_sablebook_book_id",
                table: "tb_sale_book",
                column: "book_id",
                principalTable: "tb_book",
                principalColumn: "book_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_sablebook_sale_id",
                table: "tb_sale_book",
                column: "sale_id",
                principalTable: "tb_sale",
                principalColumn: "sale_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_sablebook_book_id",
                table: "tb_sale_book");

            migrationBuilder.DropForeignKey(
                name: "fk_sablebook_sale_id",
                table: "tb_sale_book");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_sale_book_tb_book_book_id",
                table: "tb_sale_book",
                column: "book_id",
                principalTable: "tb_book",
                principalColumn: "book_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_sale_book_sales",
                table: "tb_sale_book",
                column: "sale_id",
                principalTable: "tb_sale",
                principalColumn: "sale_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
