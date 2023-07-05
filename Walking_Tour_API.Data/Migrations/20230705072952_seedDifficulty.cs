using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Walking_Tour_API.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedDifficulty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("002ae8eb-cab4-4505-bc67-a31f62bd8472"), "Hard" },
                    { new Guid("29fdefb2-d4bf-47bc-a543-daa8dc7a1cac"), "Easy" },
                    { new Guid("b4049217-996c-4208-b735-e26cf90b60da"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("065c7868-f45f-4b61-a3b8-ed193897860c"), "NSN", "Nelson", null },
                    { new Guid("4d223ce5-89ed-48fa-ab4a-652a7e66d506"), "AKL", "Auckland", null },
                    { new Guid("5d8d7a8c-bc5a-488c-b15a-f7c070992eb4"), "NTL", "Northland", null },
                    { new Guid("69b9f1f1-69a2-4044-bd43-a43987f1be14"), "WGN", "Wellington", "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("937f8117-c3e6-4e20-9961-215891b1e6c7"), "STL", "Southland", "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("f1a021f2-9fec-4bc7-ade9-8a58976d7311"), "BOP", "Bay Of Plenty", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("002ae8eb-cab4-4505-bc67-a31f62bd8472"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("29fdefb2-d4bf-47bc-a543-daa8dc7a1cac"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("b4049217-996c-4208-b735-e26cf90b60da"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("065c7868-f45f-4b61-a3b8-ed193897860c"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("4d223ce5-89ed-48fa-ab4a-652a7e66d506"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("5d8d7a8c-bc5a-488c-b15a-f7c070992eb4"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("69b9f1f1-69a2-4044-bd43-a43987f1be14"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("937f8117-c3e6-4e20-9961-215891b1e6c7"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f1a021f2-9fec-4bc7-ade9-8a58976d7311"));

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
    }
}
