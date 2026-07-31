using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TH.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddNotificationType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Notifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                columns: new[] { "CreatedDate", "Type" },
                values: new object[] { new DateTime(2026, 7, 31, 22, 38, 44, 133, DateTimeKind.Utc).AddTicks(9269), 0 });

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
                column: "CreatedDate",
                value: new DateTime(2026, 7, 31, 22, 38, 44, 133, DateTimeKind.Utc).AddTicks(9783));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Notifications");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "8bfbb160-40f6-4053-aeb9-76d84ac58cca");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "f64a02af-1585-4c28-895f-5c2b3e09a57d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8834d574-843b-44a5-bc49-6a04e0e7a837", "AQAAAAIAAYagAAAAEMkB0xBYcgidvs0BsU6tNNFg2JuEwkG2TP+2J9EgnPHKRlHwwO3W7raThbPGP+9cvA==", "8c13a8bf-f4cc-46ec-a623-1e843465d82c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4779fc4e-e181-436c-93f0-c676c0db65fe", "AQAAAAIAAYagAAAAEIyp6gRRiPRwmOVnG0I4ZXxC42Kjl8ujsj9/pdMOk5HQGC7lpjfIOl/cbiu3K7u+5g==", "f3472f9d-6014-4476-b5fe-166016f03708" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 22, 0, 14, 23, 817, DateTimeKind.Utc).AddTicks(8908));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 22, 0, 14, 23, 817, DateTimeKind.Utc).AddTicks(9072));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 22, 0, 14, 23, 817, DateTimeKind.Utc).AddTicks(9144));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 22, 0, 14, 23, 817, DateTimeKind.Utc).AddTicks(9146));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 22, 0, 14, 23, 817, DateTimeKind.Utc).AddTicks(9148));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 22, 0, 14, 23, 817, DateTimeKind.Utc).AddTicks(9149));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 22, 0, 14, 23, 817, DateTimeKind.Utc).AddTicks(9150));

            migrationBuilder.UpdateData(
                table: "TaskComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 22, 0, 14, 23, 817, DateTimeKind.Utc).AddTicks(9267));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 22, 0, 14, 23, 817, DateTimeKind.Utc).AddTicks(9354));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 22, 0, 14, 23, 817, DateTimeKind.Utc).AddTicks(9480));
        }
    }
}
