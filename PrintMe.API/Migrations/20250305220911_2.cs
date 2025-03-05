using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrintMe.API.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "idx_catalog_name",
                table: "Catalog",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "idx_catalog_description",
                table: "Catalog",
                column: "Description");

            migrationBuilder.CreateIndex(
                name: "idx_catalog_motto",
                table: "Catalog",
                column: "Motto");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_AvailableStock",
                table: "Catalog",
                column: "AvailableStock");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_Category",
                table: "Catalog",
                column: "Category");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_Price",
                table: "Catalog",
                column: "Price");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_Tags",
                table: "Catalog",
                column: "Tags");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "idx_catalog_description",
                table: "Catalog");

            migrationBuilder.DropIndex(
                name: "idx_catalog_motto",
                table: "Catalog");

            migrationBuilder.DropIndex(
                name: "IX_Catalog_AvailableStock",
                table: "Catalog");

            migrationBuilder.DropIndex(
                name: "IX_Catalog_Category",
                table: "Catalog");

            migrationBuilder.DropIndex(
                name: "IX_Catalog_Price",
                table: "Catalog");

            migrationBuilder.DropIndex(
                name: "IX_Catalog_Tags",
                table: "Catalog");

            migrationBuilder.DropIndex(
                name: "idx_catalog_name",
                table: "Catalog");
        }
    }
}
