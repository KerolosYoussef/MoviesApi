using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieRate.Infrastructure.Data.Migrations
{
    public partial class SeedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3f4c467c-e5eb-4810-9d2d-3849b0e3c719", "6724131b-08a6-473b-92b7-78a7f2c3494d", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5b1252ab-7e0f-4b70-a40d-6a3464d4feab", "153c2a71-7bbe-4ad8-9a88-c8f68a9d2f42", "User", "User" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f4c467c-e5eb-4810-9d2d-3849b0e3c719");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b1252ab-7e0f-4b70-a40d-6a3464d4feab");
        }
    }
}
