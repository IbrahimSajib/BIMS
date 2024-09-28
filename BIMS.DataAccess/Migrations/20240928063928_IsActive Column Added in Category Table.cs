using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BIMS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class IsActiveColumnAddedinCategoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IsActive",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Category");
        }
    }
}
