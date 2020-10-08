using Microsoft.EntityFrameworkCore.Migrations;

namespace AspCoreSkeletonZien.Data.Migrations
{
    public partial class addedEmailField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Members",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Members");
        }
    }
}
