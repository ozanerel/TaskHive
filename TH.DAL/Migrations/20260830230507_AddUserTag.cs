using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TH.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddUserTag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserTag",
                table: "Users",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "11701b68-04a5-4f6d-9d30-5471024173eb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "7d3fadb6-9a0f-483e-a8d3-cb6d3c4aba2d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64c91715-29bd-48d5-8188-8cd735ed1217", "AQAAAAIAAYagAAAAEBj4KQ2PTpgAPmLBPd4wwH/ukFSoYiUwfJsA2IGLwMVgMSBP0Xf3x+JwAn1Kykd7kw==", "f5b27d84-263b-4388-9b81-ef95fcb1f0bf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "41632df8-f7f0-42fb-9827-056f31cb31df", "AQAAAAIAAYagAAAAELL1qBIz913FTqwIjbliClDOxxnLeeI2eZW80S4McWQz8p5ZkrLWThcOhSEIOBfLPw==", "909c0e48-9ea3-4789-a1d7-4552ebca4620" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 30, 23, 5, 6, 247, DateTimeKind.Utc).AddTicks(461));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 30, 23, 5, 6, 247, DateTimeKind.Utc).AddTicks(656));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 30, 23, 5, 6, 247, DateTimeKind.Utc).AddTicks(741));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 30, 23, 5, 6, 247, DateTimeKind.Utc).AddTicks(743));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 30, 23, 5, 6, 247, DateTimeKind.Utc).AddTicks(752));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 30, 23, 5, 6, 247, DateTimeKind.Utc).AddTicks(754));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 30, 23, 5, 6, 247, DateTimeKind.Utc).AddTicks(755));

            migrationBuilder.UpdateData(
                table: "TaskComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 30, 23, 5, 6, 247, DateTimeKind.Utc).AddTicks(845));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 30, 23, 5, 6, 247, DateTimeKind.Utc).AddTicks(1126));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 30, 23, 5, 6, 247, DateTimeKind.Utc).AddTicks(1445));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 30, 23, 5, 6, 247, DateTimeKind.Utc).AddTicks(1447));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 30, 23, 5, 6, 247, DateTimeKind.Utc).AddTicks(1342));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UserTag" },
                values: new object[] { new DateTime(2026, 8, 30, 23, 5, 6, 247, DateTimeKind.Utc).AddTicks(1208), "ADMIN01" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UserTag" },
                values: new object[] { new DateTime(2026, 8, 30, 23, 5, 6, 247, DateTimeKind.Utc).AddTicks(1211), "AHMET01" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTag",
                table: "Users",
                column: "UserTag",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_UserTag",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserTag",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "e0cf7f09-9cc5-4b8f-acd4-d209fcd14778");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "4b514ebb-e92a-4003-ac26-406e5f78bc9c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3fe075e6-f977-430f-bf2f-4bbfc52d8fcb", "AQAAAAIAAYagAAAAEH8CMGZS0quRkICjMa5rxC7DLOpY/hO15uyAlf9EDty2Ad9oklNZKIDk0DMyiiNd8A==", "3cae9985-bd5b-4b7f-8574-8d284e7c04b5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3cf9c6d7-82f3-4db4-904f-ee187ea633dc", "AQAAAAIAAYagAAAAEDum3rSFM/5T0Ubg4JJoFHtbBi9nb6LeVU3Xpa9FCts8gSPHq2JgXG9/9/kHic2yow==", "79044a50-0ded-4ebb-8f48-d1a91c5ce375" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 30, 17, 32, 37, 620, DateTimeKind.Utc).AddTicks(335));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 30, 17, 32, 37, 620, DateTimeKind.Utc).AddTicks(981));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 30, 17, 32, 37, 620, DateTimeKind.Utc).AddTicks(1176));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 30, 17, 32, 37, 620, DateTimeKind.Utc).AddTicks(1178));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 30, 17, 32, 37, 620, DateTimeKind.Utc).AddTicks(1184));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 30, 17, 32, 37, 620, DateTimeKind.Utc).AddTicks(1186));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 30, 17, 32, 37, 620, DateTimeKind.Utc).AddTicks(1188));

            migrationBuilder.UpdateData(
                table: "TaskComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 30, 17, 32, 37, 620, DateTimeKind.Utc).AddTicks(1278));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 30, 17, 32, 37, 620, DateTimeKind.Utc).AddTicks(1341));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 30, 17, 32, 37, 620, DateTimeKind.Utc).AddTicks(1555));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 30, 17, 32, 37, 620, DateTimeKind.Utc).AddTicks(1556));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 30, 17, 32, 37, 620, DateTimeKind.Utc).AddTicks(1479));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 30, 17, 32, 37, 620, DateTimeKind.Utc).AddTicks(1391));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 30, 17, 32, 37, 620, DateTimeKind.Utc).AddTicks(1394));
        }
    }
}
