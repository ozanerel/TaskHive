using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TH.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserAndRoleSeed3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "4779fc4e-e181-436c-93f0-c676c0db65fe", "member@th.com", "MEMBER@TH.COM", "MEMBER", "AQAAAAIAAYagAAAAEIyp6gRRiPRwmOVnG0I4ZXxC42Kjl8ujsj9/pdMOk5HQGC7lpjfIOl/cbiu3K7u+5g==", "f3472f9d-6014-4476-b5fe-166016f03708", "member" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "3850b2b0-7937-4dc0-a869-5f92765f48e2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "4468e81e-82ca-4bd4-ad4a-8eaec5aa185d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "067204ed-5c09-41c9-9430-5ab24ce7ccc2", "AQAAAAIAAYagAAAAELmyJno97zmSwUwS96f5YFpFxJbhHnrNQIAcmGg1RX7QxVqPdxrA3zmL3ZSwdQdHSQ==", "67d09cce-2306-4129-9327-0234ffd79f1c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "2fe7fd5c-a9ac-4051-a2ad-28b354579806", "ozan@th.com", "OZAN@TH.COM", "OZAN", "AQAAAAIAAYagAAAAEGZ1WjtsgbDuqtVXarPEH43lSUveIMgDfr0ZhMx8TIz4oW/v7YNGCuwkQtQjyOKdsQ==", "e8738261-829b-4739-badb-2a2b1065b838", "ozan" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 22, 0, 9, 41, 556, DateTimeKind.Utc).AddTicks(9802));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 22, 0, 9, 41, 557, DateTimeKind.Utc).AddTicks(376));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 22, 0, 9, 41, 557, DateTimeKind.Utc).AddTicks(549));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 22, 0, 9, 41, 557, DateTimeKind.Utc).AddTicks(551));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 22, 0, 9, 41, 557, DateTimeKind.Utc).AddTicks(560));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 22, 0, 9, 41, 557, DateTimeKind.Utc).AddTicks(561));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 22, 0, 9, 41, 557, DateTimeKind.Utc).AddTicks(563));

            migrationBuilder.UpdateData(
                table: "TaskComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 22, 0, 9, 41, 557, DateTimeKind.Utc).AddTicks(669));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 22, 0, 9, 41, 557, DateTimeKind.Utc).AddTicks(733));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 22, 0, 9, 41, 557, DateTimeKind.Utc).AddTicks(778));
        }
    }
}
