using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieLib.Business.Migrations
{
    /// <inheritdoc />
    public partial class refixin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MoviesEF",
                keyColumn: "Id",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "MoviesEF",
                keyColumn: "Id",
                keyValue: 220);

            migrationBuilder.UpdateData(
                table: "GenresEF",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Fantasy");

            migrationBuilder.InsertData(
                table: "MoviesEF",
                columns: new[] { "Id", "Plot", "Rating", "Seen", "Title", "WatchedDate" },
                values: new object[,]
                {
                    { 2199, "When a beautiful stranger leads computer hacker Neo to a forbidding underworld, he discovers the shocking truth--the life he knows is the elaborate deception of an evil cyber-intelligence.", null, false, "The Matrix", new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2209, "78-year-old Carl Fredricksen travels to Paradise Falls in his house equipped with balloons, inadvertently taking a young stowaway.\r\n\r\n", null, false, "Up", new DateTime(2009, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MoviesEF",
                keyColumn: "Id",
                keyValue: 2199);

            migrationBuilder.DeleteData(
                table: "MoviesEF",
                keyColumn: "Id",
                keyValue: 2209);

            migrationBuilder.UpdateData(
                table: "GenresEF",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "");

            migrationBuilder.InsertData(
                table: "MoviesEF",
                columns: new[] { "Id", "Plot", "Rating", "Seen", "Title", "WatchedDate" },
                values: new object[,]
                {
                    { 219, "When a beautiful stranger leads computer hacker Neo to a forbidding underworld, he discovers the shocking truth--the life he knows is the elaborate deception of an evil cyber-intelligence.", null, false, "The Matrix", new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 220, "78-year-old Carl Fredricksen travels to Paradise Falls in his house equipped with balloons, inadvertently taking a young stowaway.\r\n\r\n", null, false, "Up", new DateTime(2009, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }
    }
}
