using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TH.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddLastReadMessageIdToConversationParticipant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LastReadMessageId",
                table: "ConversationParticipants",
                type: "int",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastReadMessageId",
                table: "ConversationParticipants");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "11b1756c-748c-4fbd-8eee-a75ffcf6a4f6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "581d53e6-ab74-4475-add3-ba5249605919");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd98da34-c080-43eb-a4f4-9eff4c004be4", "AQAAAAIAAYagAAAAEOy0FdClxS84USGATUj+HD70YDpndOOs5EflEujku3WvfuQAj106F3Z1WzWtIwS9/w==", "442aac27-4549-4656-8014-bcb251e8991f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "96137660-2593-4eca-adcd-ddaff9e926dd", "AQAAAAIAAYagAAAAEF1XVpwEY+LHPcc5AxMoNfMKkjfQB/pELTD/rNIg1Cl3ze8QsOgN/H2Ol+wf0oYfTA==", "0271a51e-3197-4c45-a1d9-844451007ae4" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 12, 16, 19, 6, 708, DateTimeKind.Utc).AddTicks(1662));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 12, 16, 19, 6, 708, DateTimeKind.Utc).AddTicks(1753));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 12, 16, 19, 6, 716, DateTimeKind.Utc).AddTicks(7649));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 12, 16, 19, 6, 716, DateTimeKind.Utc).AddTicks(7655));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 12, 16, 19, 6, 716, DateTimeKind.Utc).AddTicks(7668));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 12, 16, 19, 6, 716, DateTimeKind.Utc).AddTicks(7670));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 12, 16, 19, 6, 716, DateTimeKind.Utc).AddTicks(7672));

            migrationBuilder.UpdateData(
                table: "TaskComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 12, 16, 19, 6, 716, DateTimeKind.Utc).AddTicks(7829));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 12, 16, 19, 6, 716, DateTimeKind.Utc).AddTicks(7927));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 12, 16, 19, 6, 716, DateTimeKind.Utc).AddTicks(8361));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 12, 16, 19, 6, 716, DateTimeKind.Utc).AddTicks(8364));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 12, 16, 19, 6, 716, DateTimeKind.Utc).AddTicks(8269));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 12, 16, 19, 6, 716, DateTimeKind.Utc).AddTicks(8040));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 12, 16, 19, 6, 716, DateTimeKind.Utc).AddTicks(8045));
        }
    }
}
