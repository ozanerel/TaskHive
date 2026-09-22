using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TH.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddRequiredRoleToTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RequiredRoleId",
                table: "Tasks",
                type: "int",
                nullable: true);

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
                columns: new[] { "CreatedDate", "RequiredRoleId" },
                values: new object[] { new DateTime(2026, 9, 22, 15, 55, 54, 347, DateTimeKind.Utc).AddTicks(7084), null });

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

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_RequiredRoleId",
                table: "Tasks",
                column: "RequiredRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Roles_RequiredRoleId",
                table: "Tasks",
                column: "RequiredRoleId",
                principalTable: "Roles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Roles_RequiredRoleId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_RequiredRoleId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "RequiredRoleId",
                table: "Tasks");

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
                column: "CreatedDate",
                value: new DateTime(2026, 9, 15, 22, 39, 42, 952, DateTimeKind.Utc).AddTicks(7870));

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
    }
}
