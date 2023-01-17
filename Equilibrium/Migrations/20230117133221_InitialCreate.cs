using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Equilibrium.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    CreateUser = table.Column<string>(type: "TEXT", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServerActions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    IsHttpPost = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    CreateUser = table.Column<string>(type: "TEXT", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServerActions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    CreateUser = table.Column<string>(type: "TEXT", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccessGroupServerActionEntity",
                columns: table => new
                {
                    AccessGroupsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ActionsId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessGroupServerActionEntity", x => new { x.AccessGroupsId, x.ActionsId });
                    table.ForeignKey(
                        name: "FK_AccessGroupServerActionEntity_AccessGroups_AccessGroupsId",
                        column: x => x.AccessGroupsId,
                        principalTable: "AccessGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessGroupServerActionEntity_ServerActions_ActionsId",
                        column: x => x.ActionsId,
                        principalTable: "ServerActions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccessGroupUser",
                columns: table => new
                {
                    AccessGroupsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UsersId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessGroupUser", x => new { x.AccessGroupsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_AccessGroupUser_AccessGroups_AccessGroupsId",
                        column: x => x.AccessGroupsId,
                        principalTable: "AccessGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessGroupUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessGroupServerActionEntity_ActionsId",
                table: "AccessGroupServerActionEntity",
                column: "ActionsId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessGroupUser_UsersId",
                table: "AccessGroupUser",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessGroupServerActionEntity");

            migrationBuilder.DropTable(
                name: "AccessGroupUser");

            migrationBuilder.DropTable(
                name: "ServerActions");

            migrationBuilder.DropTable(
                name: "AccessGroups");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
