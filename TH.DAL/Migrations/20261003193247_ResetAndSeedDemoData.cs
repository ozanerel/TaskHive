using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TH.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ResetAndSeedDemoData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "47ea54bf-7641-440e-a226-7c43447f2f73");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "922ac7d2-4ce9-4543-9f70-8c81203160af");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d2be193d-12f7-4006-83d3-15c53b31f9a3", "AQAAAAIAAYagAAAAENmuq5baBTNdoR/C67M9bKMIaB8zuhbuulkMngvIDPRZ/20/WHTQBD0rOU4i6sf9Ww==", "fb768669-1738-4fdf-9def-d304fca5cdf8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "31de0e60-9446-4cc8-8701-51a1736adc13", "AQAAAAIAAYagAAAAENyymmoDsFJv3b3YlyTu4i7YqnvKZTxW0gX+/rhYFbB/BLBjxrAzKySIy7aGwhfrdA==", "0327bc0c-c9f4-4ca8-8051-64b1bc653af3" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 10, 3, 19, 32, 46, 336, DateTimeKind.Utc).AddTicks(5806));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 10, 3, 19, 32, 46, 336, DateTimeKind.Utc).AddTicks(5933));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 10, 3, 19, 32, 46, 336, DateTimeKind.Utc).AddTicks(8767));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 10, 3, 19, 32, 46, 336, DateTimeKind.Utc).AddTicks(8772));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 10, 3, 19, 32, 46, 336, DateTimeKind.Utc).AddTicks(8779));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 10, 3, 19, 32, 46, 336, DateTimeKind.Utc).AddTicks(8782));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 10, 3, 19, 32, 46, 336, DateTimeKind.Utc).AddTicks(8784));

            migrationBuilder.UpdateData(
                table: "TaskComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 10, 3, 19, 32, 46, 336, DateTimeKind.Utc).AddTicks(8898));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 10, 3, 19, 32, 46, 336, DateTimeKind.Utc).AddTicks(8976));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 10, 3, 19, 32, 46, 336, DateTimeKind.Utc).AddTicks(9305));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 10, 3, 19, 32, 46, 336, DateTimeKind.Utc).AddTicks(9308));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 10, 3, 19, 32, 46, 336, DateTimeKind.Utc).AddTicks(9192));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 10, 3, 19, 32, 46, 336, DateTimeKind.Utc).AddTicks(9057));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 10, 3, 19, 32, 46, 336, DateTimeKind.Utc).AddTicks(9062));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "f46fe1f6-006f-4823-8970-687c1c3d2bc7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "53ca2687-b247-41b2-8fac-6fb2a51f3b36");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "76a94d4e-7110-4a67-9162-d5150aec8488", "AQAAAAIAAYagAAAAEO3wBMIsntT+3Z/aIXqtzjqZ/nUJcys0IQaQc7Ahll26w6WCGOLmxPwP7QPqZLGXQQ==", "a6d1e534-6456-48a8-b774-e7c8d9814702" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "adc6034f-c179-4233-b150-9671570f0f7c", "AQAAAAIAAYagAAAAEHK/kOctEjVUfcximWHfXzmI0zJLm+zUiSAK/O8vk509mLdRVmVzqFSw+9kBjBpBsQ==", "04fc8e33-07f4-4623-b724-6d0058d265ae" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 29, 16, 14, 38, 425, DateTimeKind.Utc).AddTicks(2089));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 29, 16, 14, 38, 425, DateTimeKind.Utc).AddTicks(2937));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 29, 16, 14, 38, 425, DateTimeKind.Utc).AddTicks(3138));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 29, 16, 14, 38, 425, DateTimeKind.Utc).AddTicks(3141));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 29, 16, 14, 38, 425, DateTimeKind.Utc).AddTicks(3149));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 29, 16, 14, 38, 425, DateTimeKind.Utc).AddTicks(3151));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 29, 16, 14, 38, 425, DateTimeKind.Utc).AddTicks(3152));

            migrationBuilder.UpdateData(
                table: "TaskComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 29, 16, 14, 38, 425, DateTimeKind.Utc).AddTicks(3243));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 29, 16, 14, 38, 425, DateTimeKind.Utc).AddTicks(3325));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 29, 16, 14, 38, 425, DateTimeKind.Utc).AddTicks(3737));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 29, 16, 14, 38, 425, DateTimeKind.Utc).AddTicks(3742));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 29, 16, 14, 38, 425, DateTimeKind.Utc).AddTicks(3520));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 29, 16, 14, 38, 425, DateTimeKind.Utc).AddTicks(3415));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 29, 16, 14, 38, 425, DateTimeKind.Utc).AddTicks(3418));
        }
    }
}
