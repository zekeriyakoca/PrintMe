using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrintMe.API.Migrations
{
    /// <inheritdoc />
    public partial class _8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OriginalImageHeight",
                table: "Catalog",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OriginalImageWidth",
                table: "Catalog",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OriginalImageHeight",
                table: "Catalog");

            migrationBuilder.DropColumn(
                name: "OriginalImageWidth",
                table: "Catalog");
        }
    }
}
