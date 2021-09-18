using Microsoft.EntityFrameworkCore.Migrations;

namespace ChatAPI.Migrations
{
    public partial class Add_channels_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Channels",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Channels");
        }
    }
}
