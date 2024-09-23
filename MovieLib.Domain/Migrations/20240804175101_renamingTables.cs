using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieLib.Business.Migrations
{
    /// <inheritdoc />
    public partial class renamingTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MoviesEF",
                table: "MoviesEF");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GenresEF",
                table: "GenresEF");

            migrationBuilder.RenameTable(
                name: "MoviesEF",
                newName: "Movies");

            migrationBuilder.RenameTable(
                name: "GenresEF",
                newName: "Genre");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genre",
                table: "Genre",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genre",
                table: "Genre");

            migrationBuilder.RenameTable(
                name: "Movies",
                newName: "MoviesEF");

            migrationBuilder.RenameTable(
                name: "Genre",
                newName: "GenresEF");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoviesEF",
                table: "MoviesEF",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GenresEF",
                table: "GenresEF",
                column: "Id");
        }
    }
}
