using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Walking_Tour_API.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedRegion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("1ff2b382-fa70-4ffa-ac8e-7e33260e9d22"), "333", "Region 3", "Image Region 3" },
                    { new Guid("29c3914d-56ba-4eaf-912d-5c0740c3f7ba"), "222", "Region 2", "Image Region 2" },
                    { new Guid("dbacaf50-dd4f-4873-982e-29a9abde9eb4"), "111", "Region 1", "Image Region 1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("1ff2b382-fa70-4ffa-ac8e-7e33260e9d22"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("29c3914d-56ba-4eaf-912d-5c0740c3f7ba"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("dbacaf50-dd4f-4873-982e-29a9abde9eb4"));
        }
    }
}
