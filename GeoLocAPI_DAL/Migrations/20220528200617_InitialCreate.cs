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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                values: new object[] { 1, null, null, "No code", "No name", "127.0.0.1", null, null, null, null, null });

            migrationBuilder.InsertData(
                table: "LoginModels",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[] { 1, "$2b$10$Xr3wOLK7JECj0xeWzXyMluwhhXDpZicMOdBGHnHygQsVu5OxrKRHy", "admin" });

            migrationBuilder.InsertData(
                table: "LoginModels",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[] { 2, "$2b$10$TFmhQK92JsFXrMLgpRI32.z4.c8H/n1YXMGru.1dwmQ/0ZQ2fhFUa", "user1" });
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
