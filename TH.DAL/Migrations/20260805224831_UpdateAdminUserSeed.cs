using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TH.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAdminUserSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "6437c5da-e723-4dad-87da-d2bb6a8ae661");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "6d36bf09-f70f-4e26-aaf7-0d11234b6931");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d3767a54-d881-45a2-bafa-6f918d91d0e4", "AQAAAAIAAYagAAAAEANbDyBvp7d02I78/cjkIkAVrBmiA6gClVedqtqEy4CVAPT0bI0y6/v+5aTzctMSKQ==", "8afc3db0-ae97-44c7-8b72-4c253fa2e9a2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b234cb8-3476-48ff-bd86-09575890af88", "AQAAAAIAAYagAAAAEFBF+A5550q58KfQvfliifwJEMCXwonG1Ike8sDktEXa5NL+HdYqhDoEJ89muSNXCQ==", "46ab57e6-e536-40e5-b35a-8d4a6a3b1b55" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 22, 48, 28, 881, DateTimeKind.Utc).AddTicks(93));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 22, 48, 28, 881, DateTimeKind.Utc).AddTicks(170));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 22, 48, 28, 881, DateTimeKind.Utc).AddTicks(207));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 22, 48, 28, 881, DateTimeKind.Utc).AddTicks(208));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 22, 48, 28, 881, DateTimeKind.Utc).AddTicks(209));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 22, 48, 28, 881, DateTimeKind.Utc).AddTicks(210));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 22, 48, 28, 881, DateTimeKind.Utc).AddTicks(211));

            migrationBuilder.UpdateData(
                table: "TaskComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 22, 48, 28, 881, DateTimeKind.Utc).AddTicks(274));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 22, 48, 28, 881, DateTimeKind.Utc).AddTicks(311));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AppUserId", "CreatedDate", "Email", "FirstName", "LastName", "RoleId" },
                values: new object[] { 1, new DateTime(2026, 8, 5, 22, 48, 28, 881, DateTimeKind.Utc).AddTicks(349), "admin@test.com", "Admin", "User", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AppUserId", "CreatedDate", "DeletedDate", "Email", "FirstName", "LastName", "RoleId", "Status", "UpdatedDate" },
                values: new object[] { 2, 2, new DateTime(2026, 8, 5, 22, 48, 28, 881, DateTimeKind.Utc).AddTicks(351), null, "ahmet@test.com", "Ahmet", "Yilmaz", 3, 1, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "0d685949-c09d-4a0c-b39b-798a8521688f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "3153c3a5-1873-4114-9cb2-e0db08030543");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3fec967e-d2dc-4095-87de-e969984f10a0", "AQAAAAIAAYagAAAAEPROBpY7xsToPufkCXj+PJYMkEbjEeA5qEmQ6mBq+WxHZ6Nsvt5KtuqWkL2g0MP6Bw==", "c5cda016-412f-480d-9db3-f3cefb323ef5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9dcd4aed-3eae-4f5b-9aa3-0753613892fe", "AQAAAAIAAYagAAAAEEN0SALDbyQW+V9zUwsc2xgCoeECAUO6S1pUGt2BI85AZZbS0tH436QrONEc03JStg==", "4c3530c5-ee69-4328-b153-168e19b023e0" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 31, 22, 38, 44, 133, DateTimeKind.Utc).AddTicks(9269));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 31, 22, 38, 44, 133, DateTimeKind.Utc).AddTicks(9424));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 31, 22, 38, 44, 133, DateTimeKind.Utc).AddTicks(9489));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 31, 22, 38, 44, 133, DateTimeKind.Utc).AddTicks(9490));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 31, 22, 38, 44, 133, DateTimeKind.Utc).AddTicks(9491));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 31, 22, 38, 44, 133, DateTimeKind.Utc).AddTicks(9493));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 31, 22, 38, 44, 133, DateTimeKind.Utc).AddTicks(9494));

            migrationBuilder.UpdateData(
                table: "TaskComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 31, 22, 38, 44, 133, DateTimeKind.Utc).AddTicks(9594));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 7, 31, 22, 38, 44, 133, DateTimeKind.Utc).AddTicks(9664));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AppUserId", "CreatedDate", "Email", "FirstName", "LastName", "RoleId" },
                values: new object[] { 2, new DateTime(2026, 7, 31, 22, 38, 44, 133, DateTimeKind.Utc).AddTicks(9783), "ahmet@test.com", "Ahmet", "Yilmaz", 3 });
        }
    }
}
