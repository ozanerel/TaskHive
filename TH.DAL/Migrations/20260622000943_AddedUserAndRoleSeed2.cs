using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TH.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserAndRoleSeed2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appUserProfiles_AspNetUsers_AppUserId",
                table: "appUserProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_appUserProfiles",
                table: "appUserProfiles");

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TaskComments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameTable(
                name: "appUserProfiles",
                newName: "AppUserProfiles");

            migrationBuilder.RenameIndex(
                name: "IX_appUserProfiles_AppUserId",
                table: "AppUserProfiles",
                newName: "IX_AppUserProfiles_AppUserId");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUserProfiles",
                table: "AppUserProfiles",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "3850b2b0-7937-4dc0-a869-5f92765f48e2", "Admin", "ADMIN" },
                    { 2, "4468e81e-82ca-4bd4-ad4a-8eaec5aa185d", "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ActivationCode", "ConcurrencyStamp", "CreatedDate", "DeletedDate", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedDate", "UserName" },
                values: new object[,]
                {
                    { 1, 0, new Guid("00000000-0000-0000-0000-000000000000"), "067204ed-5c09-41c9-9430-5ab24ce7ccc2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@th.com", true, false, null, "ADMIN@TH.COM", "ADMIN", "AQAAAAIAAYagAAAAELmyJno97zmSwUwS96f5YFpFxJbhHnrNQIAcmGg1RX7QxVqPdxrA3zmL3ZSwdQdHSQ==", null, false, "67d09cce-2306-4129-9327-0234ffd79f1c", 0, false, null, "admin" },
                    { 2, 0, new Guid("00000000-0000-0000-0000-000000000000"), "2fe7fd5c-a9ac-4051-a2ad-28b354579806", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ozan@th.com", true, false, null, "OZAN@TH.COM", "OZAN", "AQAAAAIAAYagAAAAEGZ1WjtsgbDuqtVXarPEH43lSUveIMgDfr0ZhMx8TIz4oW/v7YNGCuwkQtQjyOKdsQ==", null, false, "e8738261-829b-4739-badb-2a2b1065b838", 0, false, null, "ozan" }
                });

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
                columns: new[] { "CreatedDate", "UserId" },
                values: new object[] { new DateTime(2026, 6, 22, 0, 9, 41, 557, DateTimeKind.Utc).AddTicks(669), 1 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UserId" },
                values: new object[] { new DateTime(2026, 6, 22, 0, 9, 41, 557, DateTimeKind.Utc).AddTicks(733), 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AppUserId", "CreatedDate" },
                values: new object[] { 2, new DateTime(2026, 6, 22, 0, 9, 41, 557, DateTimeKind.Utc).AddTicks(778) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_AppUserId",
                table: "Users",
                column: "AppUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserProfiles_AspNetUsers_AppUserId",
                table: "AppUserProfiles",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AspNetUsers_AppUserId",
                table: "Users",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUserProfiles_AspNetUsers_AppUserId",
                table: "AppUserProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_AspNetUsers_AppUserId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_AppUserId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUserProfiles",
                table: "AppUserProfiles");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "AppUserProfiles",
                newName: "appUserProfiles");

            migrationBuilder.RenameIndex(
                name: "IX_AppUserProfiles_AppUserId",
                table: "appUserProfiles",
                newName: "IX_appUserProfiles_AppUserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AddPrimaryKey(
                name: "PK_appUserProfiles",
                table: "appUserProfiles",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 9, 21, 30, 42, 285, DateTimeKind.Utc).AddTicks(9483));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 9, 21, 30, 42, 285, DateTimeKind.Utc).AddTicks(9695));

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "ProjectName", "Status", "UpdatedDate" },
                values: new object[] { 2, new DateTime(2026, 6, 9, 21, 30, 42, 285, DateTimeKind.Utc).AddTicks(9696), null, "Human Resources Management System", "IKYS", 1, null });

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
                columns: new[] { "CreatedDate", "UserId" },
                values: new object[] { new DateTime(2026, 6, 9, 21, 30, 42, 285, DateTimeKind.Utc).AddTicks(9766), 2 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UserId" },
                values: new object[] { new DateTime(2026, 6, 9, 21, 30, 42, 285, DateTimeKind.Utc).AddTicks(9798), 2 });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "IsCompleted", "Priority", "ProjectId", "Status", "Title", "UpdatedDate", "UserId" },
                values: new object[] { 2, new DateTime(2026, 6, 9, 21, 30, 42, 285, DateTimeKind.Utc).AddTicks(9800), null, "Develop authentication infrastructure", false, 3, 1, 1, "Implement JWT", null, 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 9, 21, 30, 42, 285, DateTimeKind.Utc).AddTicks(9833));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Email", "FirstName", "LastName", "RoleId", "Status", "UpdatedDate" },
                values: new object[,]
                {
                    { 2, new DateTime(2026, 6, 9, 21, 30, 42, 285, DateTimeKind.Utc).AddTicks(9835), null, "ayse@test.com", "Ayse", "Demir", 4, 1, null },
                    { 3, new DateTime(2026, 6, 9, 21, 30, 42, 285, DateTimeKind.Utc).AddTicks(9836), null, "mehmet@test.com", "Mehmet", "Kaya", 5, 1, null }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "IsRead", "Message", "NotificationDate", "Status", "Title", "UpdatedDate", "UserId" },
                values: new object[] { 2, new DateTime(2026, 6, 9, 21, 30, 42, 285, DateTimeKind.Utc).AddTicks(9488), null, false, "Login page task updated", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Task Updated", null, 2 });

            migrationBuilder.InsertData(
                table: "TaskComments",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "IsRead", "Message", "Status", "TaskId", "UpdatedDate", "UserId" },
                values: new object[] { 2, new DateTime(2026, 6, 9, 21, 30, 42, 285, DateTimeKind.Utc).AddTicks(9767), null, false, "JWT implementation started", 1, 2, null, 1 });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "IsCompleted", "Priority", "ProjectId", "Status", "Title", "UpdatedDate", "UserId" },
                values: new object[] { 3, new DateTime(2026, 6, 9, 21, 30, 42, 285, DateTimeKind.Utc).AddTicks(9801), null, "Write test scenarios", true, 2, 1, 1, "Prepare Test Cases", null, 3 });

            migrationBuilder.AddForeignKey(
                name: "FK_appUserProfiles_AspNetUsers_AppUserId",
                table: "appUserProfiles",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
