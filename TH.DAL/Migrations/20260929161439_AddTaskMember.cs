using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TH.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddTaskMember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskMembers",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskMembers", x => new { x.TaskId, x.UserId });
                    table.ForeignKey(
                        name: "FK_TaskMembers_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskMembers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_TaskMembers_UserId",
                table: "TaskMembers",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskMembers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "ef7158ae-7cd3-4f2a-92ca-715e0168b629");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "b5461d8a-7af2-4896-a3e3-23c525b385b1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a97b0bff-8a1c-478d-82d5-09c69bf63d7a", "AQAAAAIAAYagAAAAEK5elqz9+dzwJ4UPeFZYEo+kEtaPH2x1kIwl5fFvZ9QpFxOsA9clScMbLqWUUl4Pbw==", "e582f2a0-e010-47da-aad7-30d19f07eac4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e8fa96ee-af19-4ecb-b1b8-aed7304b7ea0", "AQAAAAIAAYagAAAAEA/DBkw7g8gn9c+qsMdie93wBU3dC19jQh34B7bbrrWkkpy9oSiv4XhN9ikqMnHcMA==", "df2ae00a-216a-46c0-b477-435086d5fe08" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 22, 15, 55, 54, 347, DateTimeKind.Utc).AddTicks(4289));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 22, 15, 55, 54, 347, DateTimeKind.Utc).AddTicks(4425));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 22, 15, 55, 54, 347, DateTimeKind.Utc).AddTicks(6910));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 22, 15, 55, 54, 347, DateTimeKind.Utc).AddTicks(6913));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 22, 15, 55, 54, 347, DateTimeKind.Utc).AddTicks(6926));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 22, 15, 55, 54, 347, DateTimeKind.Utc).AddTicks(6927));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 22, 15, 55, 54, 347, DateTimeKind.Utc).AddTicks(6929));

            migrationBuilder.UpdateData(
                table: "TaskComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 22, 15, 55, 54, 347, DateTimeKind.Utc).AddTicks(7017));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 22, 15, 55, 54, 347, DateTimeKind.Utc).AddTicks(7084));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 22, 15, 55, 54, 347, DateTimeKind.Utc).AddTicks(7461));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 22, 15, 55, 54, 347, DateTimeKind.Utc).AddTicks(7463));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 22, 15, 55, 54, 347, DateTimeKind.Utc).AddTicks(7380));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 22, 15, 55, 54, 347, DateTimeKind.Utc).AddTicks(7270));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 9, 22, 15, 55, 54, 347, DateTimeKind.Utc).AddTicks(7273));
        }
    }
}
