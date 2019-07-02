using Microsoft.EntityFrameworkCore.Migrations;

namespace InterviewLists.Persistence.Migrations
{
    public partial class addedUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Trips",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Artists",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Artists");
        }
    }
}
