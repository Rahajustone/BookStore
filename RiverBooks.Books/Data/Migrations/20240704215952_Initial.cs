using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RiverBooks.Books.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Books");

            migrationBuilder.CreateTable(
                name: "Books",
                schema: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Books",
                table: "Books",
                columns: new[] { "Id", "Author", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("5edbfe2c-f3f4-4b4c-9129-61c1b45e89d1"), "J.R.R. Tokient", 10.99m, "The followship of the Ring" },
                    { new Guid("90514419-d88a-40dc-91ea-67eb32107a29"), "J.R.R. Tokient", 20.99m, "The followship of the Ring III" },
                    { new Guid("a9eb78d7-f5e2-47a6-860d-d42d28a7214a"), "J.R.R. Tokient", 30.99m, "The followship of the Ring IV" },
                    { new Guid("e03696c8-78a3-49e7-bc48-481ef94f0483"), "J.R.R. Tokient", 12.99m, "The followship of the Ring II" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books",
                schema: "Books");
        }
    }
}
