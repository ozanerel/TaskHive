using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TH.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddTeamSystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TeamRole = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamMembers_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamMembers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "84884c05-d0f2-4582-bfe6-24e033f849bc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "1ffd28f1-7abd-4c7f-bc6f-a0a3e7dfa673");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f32ebb72-217f-47a9-872f-e5c195a55cdb", "AQAAAAIAAYagAAAAECmdRdvXvtb+rLLYfaLCXg8J19w4LutdWUsS59WtZKxAKwvV/IgINK1jLlVX5imALQ==", "1a59e2bd-f432-4bd8-b324-7ca8946a6e4e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7e3cbf02-cab9-41ca-8502-42c200a98798", "AQAAAAIAAYagAAAAEEj9d3FKQfVynDLUt8yRCDX/+rGH7CKsx65wNAC7SokPj1lfxmO2y/zEHCvrgs2aKw==", "5ed3be0c-ad8c-4c38-9d8e-fd4877746571" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 19, 15, 39, 58, 710, DateTimeKind.Utc).AddTicks(6969));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "TeamId" },
                values: new object[] { new DateTime(2026, 8, 19, 15, 39, 58, 710, DateTimeKind.Utc).AddTicks(7453), 1 });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 19, 15, 39, 58, 710, DateTimeKind.Utc).AddTicks(7564));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 19, 15, 39, 58, 710, DateTimeKind.Utc).AddTicks(7566));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 19, 15, 39, 58, 710, DateTimeKind.Utc).AddTicks(7573));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 19, 15, 39, 58, 710, DateTimeKind.Utc).AddTicks(7574));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 19, 15, 39, 58, 710, DateTimeKind.Utc).AddTicks(7578));

            migrationBuilder.UpdateData(
                table: "TaskComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 19, 15, 39, 58, 710, DateTimeKind.Utc).AddTicks(7654));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 19, 15, 39, 58, 710, DateTimeKind.Utc).AddTicks(7718));

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "Name", "Status", "UpdatedDate" },
                values: new object[] { 1, new DateTime(2026, 8, 19, 15, 39, 58, 710, DateTimeKind.Utc).AddTicks(7858), null, "TaskHive projesini geliştiren ekip.", "TaskHive Development Team", 1, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 19, 15, 39, 58, 710, DateTimeKind.Utc).AddTicks(7765));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 19, 15, 39, 58, 710, DateTimeKind.Utc).AddTicks(7767));

            migrationBuilder.InsertData(
                table: "TeamMembers",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Status", "TeamId", "TeamRole", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 8, 19, 15, 39, 58, 710, DateTimeKind.Utc).AddTicks(7924), null, 1, 1, 2, null, 1 },
                    { 2, new DateTime(2026, 8, 19, 15, 39, 58, 710, DateTimeKind.Utc).AddTicks(7925), null, 1, 1, 1, null, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_TeamId",
                table: "Projects",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_TeamId_UserId",
                table: "TeamMembers",
                columns: new[] { "TeamId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_UserId",
                table: "TeamMembers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Teams_TeamId",
                table: "Projects",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Teams_TeamId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "TeamMembers");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Projects_TeamId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Projects");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "6437c5da-e723-4dad-87da-d2bb6a8ae661");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "6d36bf09-f70f-4e26-aaf7-0d11234b6931");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d3767a54-d881-45a2-bafa-6f918d91d0e4", "AQAAAAIAAYagAAAAEANbDyBvp7d02I78/cjkIkAVrBmiA6gClVedqtqEy4CVAPT0bI0y6/v+5aTzctMSKQ==", "8afc3db0-ae97-44c7-8b72-4c253fa2e9a2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b234cb8-3476-48ff-bd86-09575890af88", "AQAAAAIAAYagAAAAEFBF+A5550q58KfQvfliifwJEMCXwonG1Ike8sDktEXa5NL+HdYqhDoEJ89muSNXCQ==", "46ab57e6-e536-40e5-b35a-8d4a6a3b1b55" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 22, 48, 28, 881, DateTimeKind.Utc).AddTicks(93));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 22, 48, 28, 881, DateTimeKind.Utc).AddTicks(170));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 22, 48, 28, 881, DateTimeKind.Utc).AddTicks(207));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 22, 48, 28, 881, DateTimeKind.Utc).AddTicks(208));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 22, 48, 28, 881, DateTimeKind.Utc).AddTicks(209));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 22, 48, 28, 881, DateTimeKind.Utc).AddTicks(210));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 22, 48, 28, 881, DateTimeKind.Utc).AddTicks(211));

            migrationBuilder.UpdateData(
                table: "TaskComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 22, 48, 28, 881, DateTimeKind.Utc).AddTicks(274));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 22, 48, 28, 881, DateTimeKind.Utc).AddTicks(311));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 22, 48, 28, 881, DateTimeKind.Utc).AddTicks(349));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 5, 22, 48, 28, 881, DateTimeKind.Utc).AddTicks(351));
        }
    }
}
