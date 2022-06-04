using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeoLocAPI_DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeoLocations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HostAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContinentCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContinentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeoLocations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoginModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginModels", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "GeoLocations",
                columns: new[] { "Id", "ContinentCode", "ContinentName", "CountryCode", "CountryName", "HostAddress", "Latitude", "Longitude", "RegionCode", "RegionName", "Zip" },
                values: new object[] { new Guid("65ebc216-74b4-4e2a-8527-d1f870eea3e4"), null, null, "No code", "No name", "127.0.0.1", null, null, null, null, null });

            migrationBuilder.InsertData(
                table: "LoginModels",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[] { new Guid("50e66a5f-61a6-457d-9cba-b9d3e5430bd3"), "$2b$10$bDz8iRZjG3zfJdi2nBezBe1UKYIuBbb/uRCUnH67mRAujtDR4LO0q", "user1" });

            migrationBuilder.InsertData(
                table: "LoginModels",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[] { new Guid("e271c897-cf27-4e2e-b80d-69cce9d79e45"), "$2b$10$WibErh/bDXtrdWxh/OkjpuJpE6JYtuMxUiEexcycimIz9fgQV5jTy", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeoLocations");

            migrationBuilder.DropTable(
                name: "LoginModels");
        }
    }
}
