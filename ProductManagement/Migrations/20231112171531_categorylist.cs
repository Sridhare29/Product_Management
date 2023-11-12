using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductManagement.Migrations
{
    /// <inheritdoc />
    public partial class categorylist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0feff3cb-c005-422d-b5c0-cfbeae3582fb"), "Watch" },
                    { new Guid("2bd55ae7-2979-48e6-b2d5-c26c6dc18647"), "iPhone" },
                    { new Guid("3b7a8617-2331-42e1-b69b-c1e92831cf28"), "Accessories" },
                    { new Guid("3dda4c07-27bf-45d9-95ea-1350c4ddd971"), "Mac" },
                    { new Guid("9825536e-74ee-4bdb-bd0b-47b1afb2867f"), "AirPods" },
                    { new Guid("c2c74b01-69fd-4440-a8c1-11217e6ff9b7"), "iPad" },
                    { new Guid("ebe6d95a-f0a8-4bcf-a6ef-293cf109ce07"), "TV & Home" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: new Guid("0feff3cb-c005-422d-b5c0-cfbeae3582fb"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: new Guid("2bd55ae7-2979-48e6-b2d5-c26c6dc18647"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: new Guid("3b7a8617-2331-42e1-b69b-c1e92831cf28"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: new Guid("3dda4c07-27bf-45d9-95ea-1350c4ddd971"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: new Guid("9825536e-74ee-4bdb-bd0b-47b1afb2867f"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: new Guid("c2c74b01-69fd-4440-a8c1-11217e6ff9b7"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: new Guid("ebe6d95a-f0a8-4bcf-a6ef-293cf109ce07"));
        }
    }
}
