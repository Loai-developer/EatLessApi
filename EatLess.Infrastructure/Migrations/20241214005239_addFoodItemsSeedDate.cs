using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EatLess.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addFoodItemsSeedDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "foodItems",
                columns: new[] { "Id", "CaloriesPerOneGram", "FoodType", "Name", "Photo" },
                values: new object[,]
                {
                    { new Guid("0877f26a-00ca-499d-b125-0585b5bcca4b"), 25m, "Fiber", "Salad", "" },
                    { new Guid("191eae96-0ab1-4ea0-8c15-359a437c2d74"), 180m, "Protein", "ChickenSighs", "" },
                    { new Guid("2170c0d5-66c2-4e7f-9403-d988f13a3032"), 140m, "Carb", "Rice", "" },
                    { new Guid("a8b70c16-5f47-4dce-b8fa-8ef2bb506a1b"), 165m, "Protein", "ChickenBreasts", "" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "foodItems",
                keyColumn: "Id",
                keyValue: new Guid("0877f26a-00ca-499d-b125-0585b5bcca4b"));

            migrationBuilder.DeleteData(
                table: "foodItems",
                keyColumn: "Id",
                keyValue: new Guid("191eae96-0ab1-4ea0-8c15-359a437c2d74"));

            migrationBuilder.DeleteData(
                table: "foodItems",
                keyColumn: "Id",
                keyValue: new Guid("2170c0d5-66c2-4e7f-9403-d988f13a3032"));

            migrationBuilder.DeleteData(
                table: "foodItems",
                keyColumn: "Id",
                keyValue: new Guid("a8b70c16-5f47-4dce-b8fa-8ef2bb506a1b"));
        }
    }
}
