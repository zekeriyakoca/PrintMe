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
            migrationBuilder.AddColumn<long>(
                name: "Category",
                table: "Catalog",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "Catalog",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SalePercentage",
                table: "Catalog",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SearchParameters",
                table: "Catalog",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "Catalog",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Tags",
                table: "Catalog",
                type: "bigint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Catalog");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Catalog");

            migrationBuilder.DropColumn(
                name: "SalePercentage",
                table: "Catalog");

            migrationBuilder.DropColumn(
                name: "SearchParameters",
                table: "Catalog");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Catalog");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "Catalog");
        }
    }
}
