using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspCoreSkeletonZien.Data.Migrations
{
    public partial class seedingDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c0a114e5-b663-45f8-8b53-facb3df11b0a", 0, "25f5842f-5924-4338-a55f-07ef8c3f2d15", "admin@domain.com", false, false, null, null, "ADMIN@DOMAIN.COM", "AQAAAAEAACcQAAAAEA+HmwcI4tGg4XODlPu2DOQ8viL8WDrkQ6kBYgyAWYgNLiriycYYmN/A9+aC+bdTvA==", null, false, "SecurityStamp", false, "admin@domain.com" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Egypt" },
                    { 2, "France" },
                    { 3, "United States" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Cairo" },
                    { 2, 1, "Giza" },
                    { 3, 1, "Alexandria" },
                    { 4, 2, "Paris" },
                    { 5, 2, "Lion" },
                    { 6, 2, "Nice" },
                    { 7, 3, "Alaska" },
                    { 8, 3, "Texas" },
                    { 9, 3, "California" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "CityId", "DateOfBirth", "EmailAddress", "FirstName", "Gender", "LastName", "MemberStatus", "Notes", "PhoneNumber", "UserProfileImage" },
                values: new object[] { 1, 1, new DateTime(1990, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "email@domain.com", "John", 1, "Doe", true, "Very Active member", "+20110000000", "profile.jpg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c0a114e5-b663-45f8-8b53-facb3df11b0a");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
