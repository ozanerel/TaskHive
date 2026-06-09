using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TH.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedTaskCompletion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Tasks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 9, 21, 30, 42, 285, DateTimeKind.Utc).AddTicks(9483));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 9, 21, 30, 42, 285, DateTimeKind.Utc).AddTicks(9488));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 9, 21, 30, 42, 285, DateTimeKind.Utc).AddTicks(9695));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 9, 21, 30, 42, 285, DateTimeKind.Utc).AddTicks(9696));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 9, 21, 30, 42, 285, DateTimeKind.Utc).AddTicks(9725));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 9, 21, 30, 42, 285, DateTimeKind.Utc).AddTicks(9727));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 9, 21, 30, 42, 285, DateTimeKind.Utc).AddTicks(9728));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 9, 21, 30, 42, 285, DateTimeKind.Utc).AddTicks(9728));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 9, 21, 30, 42, 285, DateTimeKind.Utc).AddTicks(9729));

            migrationBuilder.UpdateData(
                table: "TaskComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 9, 21, 30, 42, 285, DateTimeKind.Utc).AddTicks(9766));

            migrationBuilder.UpdateData(
                table: "TaskComments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 9, 21, 30, 42, 285, DateTimeKind.Utc).AddTicks(9767));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "IsCompleted" },
                values: new object[] { new DateTime(2026, 6, 9, 21, 30, 42, 285, DateTimeKind.Utc).AddTicks(9798), false });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "IsCompleted" },
                values: new object[] { new DateTime(2026, 6, 9, 21, 30, 42, 285, DateTimeKind.Utc).AddTicks(9800), false });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "IsCompleted" },
                values: new object[] { new DateTime(2026, 6, 9, 21, 30, 42, 285, DateTimeKind.Utc).AddTicks(9801), true });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 9, 21, 30, 42, 285, DateTimeKind.Utc).AddTicks(9833));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 9, 21, 30, 42, 285, DateTimeKind.Utc).AddTicks(9835));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 9, 21, 30, 42, 285, DateTimeKind.Utc).AddTicks(9836));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Tasks");

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 7, 15, 49, 19, 2, DateTimeKind.Utc).AddTicks(5336));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 7, 15, 49, 19, 2, DateTimeKind.Utc).AddTicks(5342));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 7, 15, 49, 19, 2, DateTimeKind.Utc).AddTicks(5599));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 7, 15, 49, 19, 2, DateTimeKind.Utc).AddTicks(5601));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 7, 15, 49, 19, 2, DateTimeKind.Utc).AddTicks(5641));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 7, 15, 49, 19, 2, DateTimeKind.Utc).AddTicks(5642));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 7, 15, 49, 19, 2, DateTimeKind.Utc).AddTicks(5643));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 7, 15, 49, 19, 2, DateTimeKind.Utc).AddTicks(5644));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 7, 15, 49, 19, 2, DateTimeKind.Utc).AddTicks(5646));

            migrationBuilder.UpdateData(
                table: "TaskComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 7, 15, 49, 19, 2, DateTimeKind.Utc).AddTicks(5694));

            migrationBuilder.UpdateData(
                table: "TaskComments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 7, 15, 49, 19, 2, DateTimeKind.Utc).AddTicks(5696));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 7, 15, 49, 19, 2, DateTimeKind.Utc).AddTicks(5739));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 7, 15, 49, 19, 2, DateTimeKind.Utc).AddTicks(5741));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 7, 15, 49, 19, 2, DateTimeKind.Utc).AddTicks(5742));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 7, 15, 49, 19, 2, DateTimeKind.Utc).AddTicks(5777));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 7, 15, 49, 19, 2, DateTimeKind.Utc).AddTicks(5779));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 7, 15, 49, 19, 2, DateTimeKind.Utc).AddTicks(5780));
        }
    }
}
