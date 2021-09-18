using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChatAPI.Migrations
{
    public partial class Add_server_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Servers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_AuthorId",
                table: "Messages",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_AuthorId",
                table: "Messages",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_AuthorId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_AuthorId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Messages");
        }
    }
}
