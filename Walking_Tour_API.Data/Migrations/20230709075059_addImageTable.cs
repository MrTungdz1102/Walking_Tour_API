using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Walking_Tour_API.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addImageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13c457a2-a8fa-4bed-ae36-4c616248811a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a739496-d3e3-43e4-9042-22182870e97b");

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("5e496212-49a1-4b88-a897-b00e4c4255db"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("d10566d7-c6f1-4cf3-a898-cb8677745329"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("ddf85d54-ef09-4c4a-8655-4509b5e89ef2"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("4ac3e92f-9ed7-4a0c-a007-549e59938a00"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("4f52aa09-8d52-4828-a830-41f32911ce9d"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("58696a42-fd02-41d7-8e50-408d96733310"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("adc9a61c-af1d-4c7d-9179-ac4732760b97"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("dab82221-dfa3-49df-90a6-6e56d53cf3f8"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f0f6fbc8-6a13-4348-b7d9-d5003b2edfbf"));

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSizeInBytes = table.Column<long>(type: "bigint", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c20777c-5953-499b-acbd-6912affdb69b", null, "Admin", "Administrator" },
                    { "4f1c83cf-8cf7-4918-87a6-b3fae6ff2efa", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("508d9d06-1d68-450b-b23a-80784982366a"), "Easy" },
                    { new Guid("9d50d974-04d8-49af-8e32-2437538ecfba"), "Hard" },
                    { new Guid("ce80e7ec-f38b-4d51-8c2c-439795422b86"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("1e190d93-7400-4d94-863a-34752650083c"), "AKL", "Auckland", null },
                    { new Guid("2995a2ff-a57e-4975-b143-78ec4ac5b931"), "STL", "Southland", "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("521ddf7e-c668-4064-9046-d4a2bc7a70e2"), "NTL", "Northland", null },
                    { new Guid("8994bfe9-6980-464e-9910-f1382ef392ce"), "NSN", "Nelson", null },
                    { new Guid("b7f293e3-03e2-474a-b15c-5ff088688426"), "WGN", "Wellington", "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("c07cb667-0a96-47de-a7a7-0b7efbfa211b"), "BOP", "Bay Of Plenty", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c20777c-5953-499b-acbd-6912affdb69b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f1c83cf-8cf7-4918-87a6-b3fae6ff2efa");

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("508d9d06-1d68-450b-b23a-80784982366a"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("9d50d974-04d8-49af-8e32-2437538ecfba"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("ce80e7ec-f38b-4d51-8c2c-439795422b86"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("1e190d93-7400-4d94-863a-34752650083c"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("2995a2ff-a57e-4975-b143-78ec4ac5b931"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("521ddf7e-c668-4064-9046-d4a2bc7a70e2"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("8994bfe9-6980-464e-9910-f1382ef392ce"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("b7f293e3-03e2-474a-b15c-5ff088688426"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("c07cb667-0a96-47de-a7a7-0b7efbfa211b"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "13c457a2-a8fa-4bed-ae36-4c616248811a", null, "User", "USER" },
                    { "6a739496-d3e3-43e4-9042-22182870e97b", null, "Admin", "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5e496212-49a1-4b88-a897-b00e4c4255db"), "Hard" },
                    { new Guid("d10566d7-c6f1-4cf3-a898-cb8677745329"), "Easy" },
                    { new Guid("ddf85d54-ef09-4c4a-8655-4509b5e89ef2"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("4ac3e92f-9ed7-4a0c-a007-549e59938a00"), "AKL", "Auckland", null },
                    { new Guid("4f52aa09-8d52-4828-a830-41f32911ce9d"), "NSN", "Nelson", null },
                    { new Guid("58696a42-fd02-41d7-8e50-408d96733310"), "NTL", "Northland", null },
                    { new Guid("adc9a61c-af1d-4c7d-9179-ac4732760b97"), "BOP", "Bay Of Plenty", null },
                    { new Guid("dab82221-dfa3-49df-90a6-6e56d53cf3f8"), "STL", "Southland", "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("f0f6fbc8-6a13-4348-b7d9-d5003b2edfbf"), "WGN", "Wellington", "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" }
                });
        }
    }
}
