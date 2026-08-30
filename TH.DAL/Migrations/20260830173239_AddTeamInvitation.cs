using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TH.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddTeamInvitation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeamInvitations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    InvitedUserId = table.Column<int>(type: "int", nullable: false),
                    InvitedByUserId = table.Column<int>(type: "int", nullable: false),
                    InvitationStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamInvitations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamInvitations_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamInvitations_Users_InvitedByUserId",
                        column: x => x.InvitedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamInvitations_Users_InvitedUserId",
                        column: x => x.InvitedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_TeamInvitations_InvitedByUserId",
                table: "TeamInvitations",
                column: "InvitedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamInvitations_InvitedUserId",
                table: "TeamInvitations",
                column: "InvitedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamInvitations_TeamId_InvitedUserId",
                table: "TeamInvitations",
                columns: new[] { "TeamId", "InvitedUserId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamInvitations");

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
                column: "CreatedDate",
                value: new DateTime(2026, 8, 19, 15, 39, 58, 710, DateTimeKind.Utc).AddTicks(7453));

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

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 19, 15, 39, 58, 710, DateTimeKind.Utc).AddTicks(7924));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 19, 15, 39, 58, 710, DateTimeKind.Utc).AddTicks(7925));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 8, 19, 15, 39, 58, 710, DateTimeKind.Utc).AddTicks(7858));

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
        }
    }
}
