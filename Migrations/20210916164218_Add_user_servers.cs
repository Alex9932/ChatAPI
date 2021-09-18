using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChatAPI.Migrations
{
    public partial class Add_user_servers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Servers_ServerId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ServerId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ServerId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "ServerUser",
                columns: table => new
                {
                    ServersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServerUser", x => new { x.ServersId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ServerUser_Servers_ServersId",
                        column: x => x.ServersId,
                        principalTable: "Servers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServerUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServerUser_UsersId",
                table: "ServerUser",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServerUser");

            migrationBuilder.AddColumn<Guid>(
                name: "ServerId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ServerId",
                table: "Users",
                column: "ServerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Servers_ServerId",
                table: "Users",
                column: "ServerId",
                principalTable: "Servers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
