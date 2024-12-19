using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EatLess.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addFoodTypeEnumValueConverter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FoodTypeEnum",
                table: "foodItems",
                newName: "FoodType");

            migrationBuilder.AlterColumn<string>(
                name: "FoodType",
                table: "foodItems",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(24)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FoodType",
                table: "foodItems",
                newName: "FoodTypeEnum");

            migrationBuilder.AlterColumn<string>(
                name: "FoodTypeEnum",
                table: "foodItems",
                type: "nvarchar(24)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
