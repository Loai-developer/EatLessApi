using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EatLess.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class convertAnemicModelsToRichDomainModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CaloriesPer100g",
                table: "foodItems");

            migrationBuilder.AddColumn<decimal>(
                name: "CaloriesPerOneGram",
                table: "foodItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "FoodTypeEnum",
                table: "foodItems",
                type: "nvarchar(24)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CaloriesPerOneGram",
                table: "foodItems");

            migrationBuilder.DropColumn(
                name: "FoodTypeEnum",
                table: "foodItems");

            migrationBuilder.AddColumn<string>(
                name: "CaloriesPer100g",
                table: "foodItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
