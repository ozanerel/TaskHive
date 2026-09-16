using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TH.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddTaskDueDateAndCompletedDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedDate",
                table: "Tasks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "Tasks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "7b2cb4f1-8f6f-4149-b290-af25bd4cfe1b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "b377d8f5-1258-4fc3-b1bd-e2b7f3005a85");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "06ff11f8-9693-45af-a1c5-3c7ff6aa199a", "AQAAAAIAAYagAAAAEO8C2WOvSkxJiaUkeBCBSmV/bQs7V8yNIli3slUurrOpdGFKHQxOje+V5l1oFEyJQQ==", "3b541172-4e59-4add-b9d0-b765d07bd91a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5d88b336-b07a-4bbc-99c3-5f1dc50da14a", "AQAAAAIAAYagAAAAECH19Nk01KSoP0ep23KQPxy9/GsOZ5nIl5TEDqoullzbhM9+x08R996dfyOPf6PNtQ==", "f200902f-ce0a-4d75-ad2d-94dc51c25752" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 15, 22, 39, 42, 952, DateTimeKind.Utc).AddTicks(6578));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 15, 22, 39, 42, 952, DateTimeKind.Utc).AddTicks(7444));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 15, 22, 39, 42, 952, DateTimeKind.Utc).AddTicks(7593));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 15, 22, 39, 42, 952, DateTimeKind.Utc).AddTicks(7594));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 15, 22, 39, 42, 952, DateTimeKind.Utc).AddTicks(7599));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 15, 22, 39, 42, 952, DateTimeKind.Utc).AddTicks(7600));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 15, 22, 39, 42, 952, DateTimeKind.Utc).AddTicks(7602));

            migrationBuilder.UpdateData(
                table: "TaskComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 15, 22, 39, 42, 952, DateTimeKind.Utc).AddTicks(7664));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CompletedDate", "CreatedDate", "DueDate" },
                values: new object[] { null, new DateTime(2026, 9, 15, 22, 39, 42, 952, DateTimeKind.Utc).AddTicks(7870), null });

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 15, 22, 39, 42, 952, DateTimeKind.Utc).AddTicks(8084));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 15, 22, 39, 42, 952, DateTimeKind.Utc).AddTicks(8085));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 15, 22, 39, 42, 952, DateTimeKind.Utc).AddTicks(8016));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 15, 22, 39, 42, 952, DateTimeKind.Utc).AddTicks(7923));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 15, 22, 39, 42, 952, DateTimeKind.Utc).AddTicks(7925));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompletedDate",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "Tasks");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "319423d2-e3fc-4045-9960-da029e25b934");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "7646528d-17b8-4c77-bc6e-096979b57fce");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e0e3071-3aed-4c1a-aefc-4e8617bc8bc3", "AQAAAAIAAYagAAAAEMyyBzCk90ZnrdvLsjoGRv3THYON2IsElsVQnHDjSuPPS9jFQE+MnBdCWuva17YqPQ==", "8dc8a18a-a956-44ae-abd7-322abe70f919" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "750e9391-6605-4cc2-ac71-c271d2abfaa8", "AQAAAAIAAYagAAAAEFkpP0WF+y3hbO6Z+uRgclnP1rlXuONxGNSZlo6/y/FEZKbUJRAE7SHBg1hvijInyA==", "3a0c3076-7f65-49ff-b8cb-07aef35e6a0f" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 15, 11, 52, 20, 895, DateTimeKind.Utc).AddTicks(5668));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 15, 11, 52, 20, 895, DateTimeKind.Utc).AddTicks(5823));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 15, 11, 52, 20, 895, DateTimeKind.Utc).AddTicks(5907));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 15, 11, 52, 20, 895, DateTimeKind.Utc).AddTicks(5910));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 15, 11, 52, 20, 895, DateTimeKind.Utc).AddTicks(5914));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 15, 11, 52, 20, 895, DateTimeKind.Utc).AddTicks(5916));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 15, 11, 52, 20, 895, DateTimeKind.Utc).AddTicks(5918));

            migrationBuilder.UpdateData(
                table: "TaskComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 15, 11, 52, 20, 895, DateTimeKind.Utc).AddTicks(6012));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 15, 11, 52, 20, 895, DateTimeKind.Utc).AddTicks(6086));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 15, 11, 52, 20, 895, DateTimeKind.Utc).AddTicks(6382));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 15, 11, 52, 20, 895, DateTimeKind.Utc).AddTicks(6384));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 15, 11, 52, 20, 895, DateTimeKind.Utc).AddTicks(6314));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 15, 11, 52, 20, 895, DateTimeKind.Utc).AddTicks(6223));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 15, 11, 52, 20, 895, DateTimeKind.Utc).AddTicks(6228));
        }
    }
}
