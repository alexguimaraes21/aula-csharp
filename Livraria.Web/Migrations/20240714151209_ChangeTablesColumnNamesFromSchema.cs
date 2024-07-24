using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Livraria.Web.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTablesColumnNamesFromSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Qty",
                table: "tb_stock",
                newName: "qty");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "tb_stock",
                newName: "book_id");

            migrationBuilder.RenameIndex(
                name: "IX_tb_stock_BookId",
                table: "tb_stock",
                newName: "IX_tb_stock_book_id");

            migrationBuilder.RenameColumn(
                name: "Publisher",
                table: "tb_book",
                newName: "publisher");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "tb_book",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "TotalPages",
                table: "tb_book",
                newName: "total_pages");

            migrationBuilder.RenameColumn(
                name: "ReleaseDate",
                table: "tb_book",
                newName: "release_date");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "tb_book",
                newName: "genre_id");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "tb_book",
                newName: "author_id");

            migrationBuilder.RenameIndex(
                name: "IX_tb_book_GenreId",
                table: "tb_book",
                newName: "IX_tb_book_genre_id");

            migrationBuilder.RenameIndex(
                name: "IX_tb_book_AuthorId",
                table: "tb_book",
                newName: "IX_tb_book_author_id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "release_date",
                table: "tb_book",
                type: "DATE",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "qty",
                table: "tb_stock",
                newName: "Qty");

            migrationBuilder.RenameColumn(
                name: "book_id",
                table: "tb_stock",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_tb_stock_book_id",
                table: "tb_stock",
                newName: "IX_tb_stock_BookId");

            migrationBuilder.RenameColumn(
                name: "publisher",
                table: "tb_book",
                newName: "Publisher");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "tb_book",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "total_pages",
                table: "tb_book",
                newName: "TotalPages");

            migrationBuilder.RenameColumn(
                name: "release_date",
                table: "tb_book",
                newName: "ReleaseDate");

            migrationBuilder.RenameColumn(
                name: "genre_id",
                table: "tb_book",
                newName: "GenreId");

            migrationBuilder.RenameColumn(
                name: "author_id",
                table: "tb_book",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_tb_book_genre_id",
                table: "tb_book",
                newName: "IX_tb_book_GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_tb_book_author_id",
                table: "tb_book",
                newName: "IX_tb_book_AuthorId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "tb_book",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATE");
        }
    }
}
